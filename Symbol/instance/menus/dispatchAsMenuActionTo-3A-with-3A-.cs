dispatchAsMenuActionTo: receiver with: argument
	^self numArgs = 0
		ifTrue: [receiver perform: self]
		ifFalse: [receiver perform: self with: argument]