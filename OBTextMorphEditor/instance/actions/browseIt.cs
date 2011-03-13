browseIt
	| symbol |
	self lineSelectAndEmptyCheck: [^ self].
	(symbol _ self selectedSymbol) isNil ifTrue: [^ view flash].

	self send: #browseIt: toModelWith: {symbol} orDo: [super browseIt]