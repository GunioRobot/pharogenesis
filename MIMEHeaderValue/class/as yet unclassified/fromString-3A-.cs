fromString: aString 
	| parts newValue parms separatorPos parmName parmValue |
	parts _ ReadStream on: (aString findTokens: ';').
	newValue _ self new mainValue: parts next asLowercase.
	parms _ Dictionary new.
	parts do: 
		[:e | 
		separatorPos _ e findAnySubStr: '=' startingAt: 1. 
		separatorPos <= e size
			ifTrue: 
				[parmName _ (e copyFrom: 1 to: separatorPos - 1) withBlanksTrimmed.
				parmValue _ (e copyFrom: separatorPos + 1 to: e size) withBlanksTrimmed withoutQuoting.
				parms at: parmName put: parmValue]].
	newValue parameters: parms.
	^ newValue