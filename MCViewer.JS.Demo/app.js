'use strict';

const axios = require('axios')
const open = require('open');


var postObj = ({
	hookUrl: 'https://www.2ba.nl',
	languageCode: 'NL',
	content: {
		classId: "MC000043",
		features: [
			{
				featureId: "EF010527",
				portcode: 2,
				numericValue: 89,
				logicalValue: null,
				rangeLowerValue: null,
				rangeUpperValue: null,
				alphaNumericValue: null
			}
		]
	}
});

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
	});