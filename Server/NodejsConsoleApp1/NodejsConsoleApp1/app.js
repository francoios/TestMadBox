const express = require('express');
const app = express();
const port = 3000;

var fs = require("fs");
var obj = {
    users: []
};

app.get('/', (req, res) => res.send('Welcome to the ultimate ScoreBoard Project, there are 2 root that can give you either GetScore(no param) , or AddScore (2 param User;Score)<br/>Exemples :<br/>' +
    'http://localhost:3000/GetScore' +
    '<br/>'+
    'http://localhost:3000/AddScore?user=toto&score=500'));

app.get('/TestServer', (req, res) => {
    res.send("ok");
});

app.get('/GetScore', (req, res) => {
    fs.readFile('scores.json', 'utf8', function readFileCallback(err, data) {
        if (err)
            res.send("NO SCORE");
        else
            res.send(data);
    });
});

app.get('/AddScore', (req, res) => {
    fs.readFile('scores.json', 'utf8', function readFileCallback(err, data) {
        if (err) {
            obj.users.push({ user: req.query.user, score: req.query.score });
            var json = JSON.stringify(obj);
            fs.writeFile('scores.json', json, 'utf8', (res) => { });
            res.send("ok");
        } else {
            obj = JSON.parse(data); //now it an object
            obj.users.push({ user: req.query.user, score: req.query.score }); 
            var json = JSON.stringify(obj); 
            fs.writeFile('scores.json', json, 'utf8', (res) => {
            }); 
            res.send("ok");
        }
    });
});

app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`));