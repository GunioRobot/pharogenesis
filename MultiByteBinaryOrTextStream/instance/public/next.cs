next

	| n |
	n _ self converter nextFromStream: self.
	n ifNil: [^ nil].
	isBinary and: [n isCharacter ifTrue: [^ n asciiValue]].
	^ n.
