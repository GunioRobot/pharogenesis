projectWithNameOrCurrent: aString
"
CurrentProjectRefactoring projectWithNameOrCurrent:
"
	self deprecated: 'CurrentProjectRefactoring is deprecated'.
	
	^(Project named: aString) ifNil: [self xxxCurrent]