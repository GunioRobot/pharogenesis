secCanCreate: netType SocketOfType: socketType
	self export: true.
	^self cCode: 'ioCanCreateSocketOfType(netType, socketType)'