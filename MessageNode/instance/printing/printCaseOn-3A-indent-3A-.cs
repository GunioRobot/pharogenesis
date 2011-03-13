printCaseOn: aStream indent: level
	"receiver caseOf: {[key]->[value]. ...} otherwise: [otherwise]"

	| braceNode otherwise extra |
	braceNode _ arguments first.
	otherwise _ arguments last.
	((arguments size = 1) or: [otherwise isJustCaseError])
		ifTrue: [otherwise _ nil].
	receiver printOn: aStream indent: level precedence: 3.
	aStream nextPutAll: ' caseOf: {'; crtab: level+1.
	braceNode casesForwardDo:
		[:keyNode :valueNode :last |
		keyNode printOn: aStream indent: level+1.
	 	aStream nextPutAll: ' -> '.
		extra _ valueNode isComplex ifTrue: [aStream crtab: level+2. 1] ifFalse: [0].
	 	valueNode printOn: aStream indent: level+1+extra.
	 	last ifTrue: [aStream nextPut: $}] ifFalse: [aStream nextPut: $.; crtab: level+1]].
	otherwise isNil
		ifFalse:
			[aStream crtab: level+1; nextPutAll: 'otherwise: '.
			 extra _ otherwise isComplex ifTrue: [aStream crtab: level+2. 1] ifFalse: [0].
			 otherwise printOn: aStream indent: level+1+extra]