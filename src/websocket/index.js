const app = require('express')();
const http = require('http').createServer(app);
const io = require('socket.io')(http, {
  cors: {
    origin: '*',
  }});
app.get('/', (req, res) => {
  res.send('<h1>Hey Socket.io</h1>');
});
io.on('connection', (socket) => {
  socket.on('pedido event', (msg) => {
    io.emit('pedido broadcast', `server: ${msg}`);
  });
});



http.listen(3000, () => {
  console.log('listening on *:3000');
});

