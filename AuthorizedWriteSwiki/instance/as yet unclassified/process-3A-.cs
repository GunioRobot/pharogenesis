process: request
	"Only demand authorization of name and password when requesting the edit page, requesting the append page, receiving an edit, or receiving an append."

	| command coreRef |
	request fields ifNotNil: ["Are there input fields?"
		coreRef _ request message size < 2
			ifTrue: ['1']
			ifFalse: [request message at: 2].
		coreRef = 'searchresult' ifFalse: ["Must be text for an edit!"
			self checkAuthorization: request]].
	request message size > 2 ifTrue:
			["SearchResult, All, Versions, or Edit"
			command _ request message at: 3.
			command = 'edit' ifTrue:
					[self checkAuthorization: request].
			command = 'insert' ifTrue:
					[self checkAuthorization: request]].

	^(super processSpecial: request).		"all the way up to SwikiAction"