const fs = require("fs"),
      path = require("path");


let lang_strings = [

];

let langs  = ["eng", "ned"];
let output_path = "frontend_dev/Assets/lang/";




let get_path = (filename, ext=".json") => {return path.join(__dirname, "..",  output_path + filename + ext)};

langs.forEach((lang) => {
    let transl = JSON.parse(fs.readFileSync(get_path(lang)));

});


function get_lang_js() {
    return `function get_safe_lang(lang) {
    let lang_strings = ${lang_strings.toString()};
    let ret = {};
    lang_strings.forEach((key) => {
        if (lang[key] === undefined){
            throw "lang is missing translation for: " + key;
        }
        ret[key] = lang[key];
    });
    return ret;
}`
}
