primAECreateDesc: typeCode from: aString

	|rcvr size |
	rcvr _ self 	primitive: 	'primAECreateDesc'
				parameters:	#(DescType String)
				receiver:	#AEDesc.
	size _ aString size.
	^(self 
		cCode: 'AECreateDesc(*typeCode, aString, size, rcvr)'
		inSmalltalk: [[rcvr. size]. -1]) asOop: Unsigned
