fixAlansOldEventHandlers

	(#(programmedMouseUp:for: programmedMouseUp:for:with:) 
			includes: mouseUpSelector) ifFalse: [^self].
	mouseDownSelector ifNotNil: [^self].
	mouseUpRecipient addMouseUpActionWith: (
		mouseUpRecipient valueOfProperty: #mouseUpCodeToRun ifAbsent: [valueParameter]
	)
