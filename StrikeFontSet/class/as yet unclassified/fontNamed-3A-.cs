fontNamed: aString

	^ self allInstances detect: [:inst | inst name = aString] ifNone: [TextStyle defaultFont]
