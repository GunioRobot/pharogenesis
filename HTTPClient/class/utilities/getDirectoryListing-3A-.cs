getDirectoryListing: dirListURL
	"HTTPClient getDirectoryListing: 'http://www.squeakalpha.org/uploads' "
	| answer ftpEntries |
"	answer _ self 
		httpPostDocument: dirListURL
		args: Dictionary new."
	"Workaround for Mac IE problem"
	answer _ self httpGetDocument: dirListURL.
	answer isString
		ifTrue: [^self error: 'Listing failed: ' , answer]
		ifFalse: [answer _ answer content].
	answer first == $<
		ifTrue: [self error: 'Listing failed: ' , answer].
	ftpEntries _ answer findTokens: String crlf.
	^ ftpEntries 
		collect:[:ftpEntry | ServerDirectory parseFTPEntry: ftpEntry]
		thenSelect: [:entry | entry notNil]