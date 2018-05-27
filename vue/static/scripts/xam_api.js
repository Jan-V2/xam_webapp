let url_prefx;
let test_url = (q) => {return url_prefx + "test:" + q};

api = {
    get_lang: function (lang) {
        // takes a lang arg that matches a json file in the lang folder
        return JSON.parse(http_get("lang/"+lang+".json"));
    },

    test: {
        sqlite: function () {
            location.href = test_url("sqlite")
        }
    }
};
