
const express = require('express');
const path = require('path');
const PORT = process.env.PORT || 5000;
const mock_api = require("./mock_api");


app = express()
    .use(express.static(path.join(__dirname, '/../frontend_dev')))
    .use("/api", mock_api)
    .set('views', path.join(__dirname, 'views'))
    .set('view engine', 'ejs')
    .listen(PORT, () => console.log(`Listening on ${ PORT }`));
