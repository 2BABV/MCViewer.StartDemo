'use strict';

const axios = require('axios')
const open = require('open');


var postObj = {
    hookUrl: 'https://www.2ba.nl',
    languageCode: 'NL',
    json: JSON.stringify({
        "ClassId": "MC000043",
        "Features": [
            {
                "FeatureId": "EF010527",
                "Portcode": 2,
                "NumericValue": 89,
                "LogicalValue": null,
                "RangeLowerValue": null,
                "RangeUpperValue": null,
                "AlphaNumericValue": null
            }
        ]
    })
};

console.log(postObj);

axios
    .post('https://mc.2ba.nl/ApiService/GetViewCodeFromInputFromBody', postObj, {
        headers: {
            'Content-Type': 'application/json',
        }
    })
    .then((res) => {
        console.log(`statusCode: ${res.statusCode}`)
        console.log(res.data)

        open("https://mc.2ba.nl/NL/View/" + res.data.ViewCode);
    })
    .catch((error) => {
        console.error(error)
    });
