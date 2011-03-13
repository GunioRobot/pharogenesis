variable: aVariable value: expression from: encoder

	(aVariable isMemberOf: MessageNode)
		ifTrue: [^aVariable store: expression from: encoder].
	variable _ aVariable.
	value _ expression