secCan: socket ListenOnPort: port
	self export: true.
	^self cCode: 'ioCanListenOnPort(socket, port)'