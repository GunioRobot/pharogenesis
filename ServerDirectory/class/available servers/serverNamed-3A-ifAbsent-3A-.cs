serverNamed: nameString ifAbsent: aBlock
	^self servers at: nameString asString ifAbsent: [aBlock value]