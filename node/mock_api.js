
const express = require("express");
const fs = require("fs");

let mock_api = express.Router();

mock_api.get("/:get_lang", function(req, res) {
/*    // takes a lang arg that matches a json file in the lang folder
    let lang = req.query.lang;
    res.send(fs.readFileSync())*/
});


module.exports = mock_api;
