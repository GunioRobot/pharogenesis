kindOfSubclass
	"Answer a string that describes what kind of subclass the receiver is, i.e.,
	weak, variable, variable byte, variable word, or not variable."
	self isWeak ifTrue:[^' weakSubclass: '].
	self isVariable
		ifTrue: [self isBits
					ifTrue: [self isBytes
								ifTrue: [^' variableByteSubclass: ']
								ifFalse: [^' variableWordSubclass: ']]
					ifFalse: [^' variableSubclass: ']]
		ifFalse: [^' subclass: ']