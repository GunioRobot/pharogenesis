filterToSendersOf
	"Filter the receiver's list down to only those items which send a given selector"
	| aFragment inputWithBlanksTrimmed aMethod |
	aFragment := UIManager default 
		request: 'type selector:'
		initialAnswer: ''.
	aFragment isEmptyOrNil ifTrue: [ ^ self ].
	inputWithBlanksTrimmed := aFragment withBlanksTrimmed.
	Symbol 
		hasInterned: inputWithBlanksTrimmed
		ifTrue: 
			[ :aSymbol | 
			self filterFrom: 
				[ :aClass :aSelector | 
				(aMethod := aClass compiledMethodAt: aSelector) notNil and: [ aMethod refersToLiteral: aSymbol ] ] ]