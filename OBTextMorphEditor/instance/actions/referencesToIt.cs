referencesToIt

	| selector |
	self lineSelectAndEmptyCheck: [^ self].
	(selector _ self selectedSelector) == nil ifTrue: [^ view flash].
	self send: #referencesToIt: toModelWith: {selector} orDo: [super referencesToIt]