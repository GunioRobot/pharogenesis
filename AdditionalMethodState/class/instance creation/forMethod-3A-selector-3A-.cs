forMethod: aMethod selector: aSelector
	^(self basicNew: 0)
		selector: aSelector;
		setMethod: aMethod;
		yourself