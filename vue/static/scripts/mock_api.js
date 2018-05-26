api = {
    get_lang: function (lang) {
        // takes a lang arg that matches a json file in the lang folder
        return JSON.parse(http_get("lang/"+lang+".json"));
    },


};
