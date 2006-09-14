generateCS: extensionAndNumber fromUpdate: updateNumber on: st
	
	st nextPutAll:
'"Postscript:
Leave the line above, and replace the rest of this comment by a useful one.
Executable statements should follow this comment, and should
be separated by periods, with no exclamation points (!!).
Be sure to put any further comments in double-quotes, like this one."

|repository|
repository := MCHttpRepository
                location: ''http://source.squeakfoundation.org/39a''
                user: ''''
                password: ''''.
(repository loadVersionFromFileNamed:' .
	st nextPut: $' ; nextPutAll: 'ScriptLoader', extensionAndNumber, '.mcz'') load.'; cr.
	st nextPutAll: 'ScriptLoader new updateFrom', (updateNumber-1) asString; nextPutAll: '.' ; cr.
	st nextPutAll: '!'.
	^ st contents
