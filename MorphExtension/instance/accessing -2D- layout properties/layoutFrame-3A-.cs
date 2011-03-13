layoutFrame: aLayoutFrame 
	aLayoutFrame
		ifNil: [self removeProperty: #layoutFrame]
		ifNotNil: [self setProperty: #layoutFrame toValue: aLayoutFrame]