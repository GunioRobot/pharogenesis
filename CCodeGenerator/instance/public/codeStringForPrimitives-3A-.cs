codeStringForPrimitives: classAndSelectorList 
"TPR - appears to be obsolete now"
	self addMethodsForPrimitives: classAndSelectorList.
	^self generateCodeStringForPrimitives