acceptConnection: stringSocket
	stringSocket nextPut: (UMProtocolVersion version: 1) asStringArray.
	connections add: stringSocket