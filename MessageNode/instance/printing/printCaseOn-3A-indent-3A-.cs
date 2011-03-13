printCaseOn: aStream indent: level 
	"receiver caseOf: {[key]->[value]. ...} otherwise: [otherwise]"
	| braceNode otherwise extra |
	braceNode _ arguments first.
	otherwise _ arguments last.
	(arguments size = 1 or: [otherwise isJustCaseError])
		ifTrue: [otherwise _ nil].
	receiver
		printOn: aStream
		indent: level
		precedence: 3.
	aStream nextPutAll: ' caseOf: '.
	braceNode isVariableReference ifTrue: [braceNode printOn: aStream indent: level]
		ifFalse: 
			[aStream nextPutAll: '{';
				 crtab: level + 1.
			braceNode
				casesForwardDo: 
					[:keyNode :valueNode :last | 
					keyNode printOn: aStream indent: level + 1.
					aStream nextPutAll: ' -> '.
					valueNode isComplex
						ifTrue: 
							[aStream crtab: level + 2.
							extra _ 1]
						ifFalse: [extra _ 0].
					valueNode printOn: aStream indent: level + 1 + extra.
					last ifTrue: [aStream nextPut: $}]
						ifFalse: [aStream nextPut: $.;
								 crtab: level + 1]]].
	otherwise isNil
		ifFalse: 
			[aStream crtab: level + 1;
			nextPutAll: ' otherwise: '.
			otherwise isComplex
				ifTrue: 
					[aStream crtab: level + 2.
					extra _ 1]
				ifFalse: [extra _ 0].
			otherwise printOn: aStream indent: level + 1 + extra.]