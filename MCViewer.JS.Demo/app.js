'use strict';

const axios = require('axios')
const open = require('open');
const fs = require('fs');

var postObj = JSON.parse(fs.readFileSync("./payload.json")); // json.parse because readFileSync returns raw data (bytes)

console.log(postObj);
let baseUrl = "https://mc.2ba.nl";
axios
	.post(baseUrl + '/ApiService/GetViewCodeFromInputFromBody', postObj, {
		headers: {
			'Content-Type': 'application/json',
		}
	})
	.then((res) => {
		console.log(`statusCode: ${res.status} - ${res.statusText}`)
		console.log(res.data)

		open(baseUrl + "/NL/View/" + res.data.ViewCode);
	})
	.catch((error) => {
		console.error(error)
	}).then(async (res) => {
		// Hack to "sleep" and prevent node.js from exiting so you can read the output.
		await new Promise(resolve => setTimeout(resolve, 10000));
	});

