// // const express = require("express");
// // const WebSocket = require("ws");
// // const path = require("path");
// // const mongodb = require("mongodb");
// // const mqtt = require("mqtt");
// // require("dotenv").config();
// //
// // //console.log(process.env);
// // //const client = mqtt.connect(process.env.LOCALHOST)
// // const client = mqtt.connect("mqtt://broker.hivemq.com");
// // const topicName = "aedes/test";
// //
// // const MongoClient = mongodb.MongoClient;
// // const uri = "mongodb://localhost/";
// // const app = express();
// // const router = express.Router();
// //
// //
// // const wss = new WebSocket.Server({ port: 3001 });
// //
// //
// // wss.on("connection", function connection(ws) {
// //     ws.on("message", function incoming(message) {
// //         console.log("received: %s", message);
// //     });
// //     ws.send("Client recording...");
// // });
// //
// // //add the router
// // app.use('/', router);
// // app.listen(process.env.port || 8080);
// //
// // console.log('Running at Port 8080');
// //
// // router.get('/login',function(req,res){
// //     res.sendFile(path.join(__dirname+'/Web/Doctor/login.html'));
// //     //__dirname : It will resolve to your project folder.
// // });
// //
// // router.get('/',function(req,res){
// //     res.sendFile(path.join(__dirname+'/templates/Start.html'));
// //     //__dirname : It will resolve to your project folder.
// // });
// //
// // router.get('/patient-profile',function(req,res){
// //     res.sendFile(path.join(__dirname+'/templates/profile.html'));
// //     //__dirname : It will resolve to your project folder.
// // });
// //
// // router.get('/live-data',function(req,res){
// //     res.sendFile(path.join(__dirname+'/templates/LiveRecord.html'));
// // });
// //
// // router.get('/history',function(req,res){
// //     res.sendFile(path.join(__dirname+'/templates/History.html'));
// // });
// //
// // router.get('/manual-upload',function(req,res){
// //     res.sendFile(path.join(__dirname+'/templates/ManualUpload.html'));
// // });
// //
// // router.get('/medicine-time',function(req,res){
// //     res.sendFile(path.join(__dirname+'/templates/MedTime.html'));
// // });
// //
// // // connect to same client and subscribe to same topic name
// // client.on("connect", () => {
// //     // can also accept objects in the form {'topic': qos}
// //     client.subscribe(topicName, (err, granted) => {
// //         if (err) {
// //             console.log(err, "err");
// //         }
// //         console.log(granted, "granted");
// //     });
// // });
// //
// // // on receive message event, log the message to the console
// // client.on("message", (topic, message, packet) => {
// //     console.log(packet, packet.payload.toString());
// //     if (topic === topicName) {
// //         var rev_message = JSON.parse(message);
// //         console.log(rev_message);
// //         // var patient_id = rev_message.patient_id;
// //         // var timestamp = rev_message.timestamp;
// //         // var temperature = rev_message.temperature;
// //         // var pulse_rate = rev_message.pulse_rate;
// //         // var oxygen_level = rev_message.oxygen_level;
// //         // const data = {
// //         //     patient: patient_id,
// //         //     timestamp: timestamp,
// //         //     value: temperature,
// //         //     pulse: pulse_rate,
// //         //     oxygen: oxygen_level
// //         // };
// //         async function pushInDb() {
// //             const client = new MongoClient(uri, { useUnifiedTopology: true });
// //             try {
// //                 await client.connect();
// //
// //                 const database = client.db("TemperatureDB");
// //                 const temperatureColl = database.collection("temperature");
// //                 // create a document to be inserted
// //                 // const doc = {
// //                 //     patient: patient_id,
// //                 //     timestamp: timestamp,
// //                 //     value: temperature,
// //                 //     pulse: pulse_rate,
// //                 //     oxygen: oxygen_level
// //                 // };
// //
// //                 const result = await temperatureColl.insertOne(rev_message);
// //                 console.log(
// //                     `${result.insertedCount} documents were inserted with the _id: ${result.insertedId}`
// //                 );
// //             } finally {
// //                 await client.close();
// //             }
// //         }
// //         pushInDb().catch(console.dir);
// //         async function pushToClient() {
// //             wss.clients.forEach(function each(client) {
// //                 if (client.readyState === WebSocket.OPEN) {
// //                     client.send(JSON.stringify(rev_message));
// //                 }
// //             });
// //         }
// //         pushToClient().catch(console.dir);
// //     }
// // });
// //
// // client.on("packetsend", (packet) => {
// //     console.log(packet, "packet2");
// // });
// //

const bodyParser = require("body-parser");
const express = require("express");
const router = express.Router();
const http = require('http');

var port = 8080;

const requestListener = function (req, res) {
    res.writeHead(200);
    res.end('Hello, World!');

    const chunks = [];
    req.on('data', chunk => chunks.push(chunk));
    req.on('end', () => {
        const data = Buffer.concat(chunks);
        //console.log(data.toString('base64'));
        console.log(data.toString()); // %2c is the comma in the string
    })
}

const server = http.createServer(requestListener);
server.listen(port, () => {
    console.log(`server is running at ${port}`);
  }); //the server object listens on port 8080

// var http = require('http');
// var fs = require('fs');

// http.createServer(function (req, res) {

//     console.log('Request Received');

//     res.writeHead(200, {
//         'Context-Type': 'text/plain',
//         'Access-Control-Allow-Origin': '*'
//     });

//     req.on('data', function (chunk) {
//         var rstream = fs.createReadStream(JSON.parse(chund));
//         var wstream = fs.createWriteStream('info.txt');
//         rstream.pipe(wstream);
//         str += chunk;
//         console.log('GOT DATA');
//     });

//     res.end('{"msg": "OK"}');
// }).listen(8080, '127.0.0.1');
// console.log('Server running at http://127.0.0.1:8080/');