fromMIMEHeader: aString
	"This is the value of a MIME header field and so is parsed to extract the various parts"

	| parts newValue parms separatorPos parmName parmValue |

	newValue _ self new.

	parts _ ReadStream on: (aString findTokens: ';').
	newValue mainValue: parts next.
	parms _ Dictionary new.
	parts do: 
		[:e | 
		separatorPos _ e findAnySubStr: '=' startingAt: 1. 
		separatorPos <= e size
			ifTrue: 
				[parmName _ (e copyFrom: 1 to: separatorPos - 1) withBlanksTrimmed asLowercase.
				parmValue _ (e copyFrom: separatorPos + 1 to: e size) withBlanksTrimmed withoutQuoting.
				parms at: parmName put: parmValue]].
	newValue parameters: parms.
	^ newValue
