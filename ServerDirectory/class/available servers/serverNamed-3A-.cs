serverNamed: nameString
	^ Servers at: nameString asString
		ifAbsent: [self error: 'Server name not found']