projectWithNameOrCurrent: aString
"
CurrentProjectRefactoring projectWithNameOrCurrent:
"
	^(Project named: aString) ifNil: [self xxxCurrent]