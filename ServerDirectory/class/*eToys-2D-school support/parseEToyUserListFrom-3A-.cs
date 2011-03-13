parseEToyUserListFrom: urlString
	| url userString userList |
	urlString ifNil:[^nil].
	url _ urlString asUrl.
	["Note: We need to prevent going through the plugin API 
	when retrieving a local (file) URL, since the plugin API
	(correctly) rejects file:// downloads."
		Cursor wait showWhile:[
			(url hasRemoteContents) ifTrue:[
				"Go through the browser (if present)"
				userString _ (HTTPClient httpGet: url asString) contents.
			] ifFalse:[
				"Go grab it directly"
				userString _ url retrieveContents contents.
			].
		].
	] on: Error do:[:ex| userString _ nil. ex return].
	userString ifNil:[^nil].
	"Get rid of any line ending problems"
	userString _ userString copyReplaceAll: String crlf with: String cr.
	userString _ userString copyReplaceAll: String lf with: String cr.
	userList _ (userString findTokens: Character cr) collect:[:each| each withBlanksTrimmed].
	userList _ userList reject:[:any| any isEmpty].
	(userList first = '##user list##') ifFalse:[^nil].
	userList _ userList copyFrom: 2 to: userList size.
	^userList