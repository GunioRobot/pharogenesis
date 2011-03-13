parseEToyUserListFrom: urlString
	| url userString userList |
	urlString ifNil:[^nil].
	url := urlString asUrl.
	["Note: We need to prevent going through the plugin API 
	when retrieving a local (file) URL, since the plugin API
	(correctly) rejects file:// downloads."
		Cursor wait showWhile:[
			(url hasRemoteContents) ifTrue:[
				"Go through the browser (if present)"
				userString := (HTTPClient httpGet: url asString) contents.
			] ifFalse:[
				"Go grab it directly"
				userString := url retrieveContents contents.
			].
		].
	] on: Error do:[:ex| userString := nil. ex return].
	userString ifNil:[^nil].
	"Get rid of any line ending problems"
	userString := userString copyReplaceAll: String crlf with: String cr.
	userString := userString copyReplaceAll: String lf with: String cr.
	userList := (userString findTokens: Character cr) collect:[:each| each withBlanksTrimmed].
	userList := userList reject:[:any| any isEmpty].
	(userList first = '##user list##') ifFalse:[^nil].
	userList := userList copyFrom: 2 to: userList size.
	^userList