removeServerNamed: nameString ifAbsent: aBlock
	self servers removeKey: nameString ifAbsent: [aBlock value]