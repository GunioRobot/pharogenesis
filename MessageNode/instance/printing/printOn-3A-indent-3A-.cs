printOn: aStream indent: level

	| printer leadingKeyword |
	special > 0 ifTrue: [printer _ MacroPrinters at: special].
	(special > 0)
		ifTrue: [self perform: printer with: aStream with: level]
		ifFalse: [selector key first = $:
				ifTrue: [leadingKeyword _ selector key keywords first.
						aStream nextPutAll: leadingKeyword; space.
						self printReceiver: receiver on: aStream indent: level.
						self printKeywords: (selector key allButFirst: leadingKeyword size + 1) arguments: arguments
							on: aStream indent: level]
				ifFalse: [(aStream dialect = #SQ00 and: [selector key == #do:])
						ifTrue: ["Add prefix keyword"
								aStream withStyleFor: #prefixKeyword do: [aStream nextPutAll: 'Repeat '].
								self printParenReceiver: receiver on: aStream indent: level + 1.
								self printKeywords: selector key arguments: arguments
									on: aStream indent: level prefix: true]
						ifFalse: [self printReceiver: receiver on: aStream indent: level.
								self printKeywords: selector key arguments: arguments
									on: aStream indent: level]]]