const fs = require("fs"),
      rm = require("rimraf"),
      ncp = require('ncp').ncp;

process.chdir(__dirname);

let base_dir = "./../../webapp/";

let html = fs.readFileSync("./../dist/index.html", "utf8");
html = html.replace(/=\//g, "=");
fs.writeFileSync( base_dir + "Assets/index.html", html, "utf8");

let static_dir = base_dir + "Assets/static/";

if(fs.existsSync(static_dir)){
    rm(static_dir, function () {
        rest_of_code()
    });
}else{
    rest_of_code()
}

function rest_of_code(){
    ncp.limit = 16;

    ncp("./../dist/static/",static_dir, function (err) {
        if (err) {
            return console.error(err);
        }
        console.log('done!');
    });
}

