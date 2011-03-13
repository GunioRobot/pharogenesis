printOn: aStream indent: level

	| printer |
	special > 0 ifTrue: [printer _ MacroPrinters at: special].
	(printer == #printCaseOn:indent:) ifTrue: 
		[^self printCaseOn: aStream indent: level].
	receiver == nil 
		ifFalse: [receiver printOn: aStream indent: level precedence: precedence].
	(special > 0)
		ifTrue: 
			[self perform: printer with: aStream with: level]
		ifFalse: 
			[self 
				printKeywords: selector key
				arguments: arguments
				on: aStream
				indent: level]