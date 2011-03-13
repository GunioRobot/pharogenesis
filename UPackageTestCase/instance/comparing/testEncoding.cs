testEncoding
	self should: [ p1 = (UPackage decodeFromStringStream: (ReadStream on: p1 stringArrayEncoding)) ].