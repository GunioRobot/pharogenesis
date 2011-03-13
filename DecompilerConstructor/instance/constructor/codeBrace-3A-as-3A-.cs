codeBrace: elements as: receiver

	| braceNode |
	braceNode _ self codeBrace: elements.
	^(receiver isVariableReference and: [receiver key key == #Array])
		ifTrue: [braceNode]
		ifFalse:
			[self codeMessage: (braceNode collClass: receiver)
					selector: (self codeSelector: #as: code: -1)
					arguments: (Array with: receiver)]