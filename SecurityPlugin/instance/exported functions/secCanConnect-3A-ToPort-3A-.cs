secCanConnect: addr ToPort: port
	self export: true.
	^self cCode: 'ioCanConnectToPort(addr, port)'