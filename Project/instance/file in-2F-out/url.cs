url
	| firstURL |
	"compose my url on the server"

	urlList isEmptyOrNil ifTrue: [^''].
	firstURL _ urlList first.
	firstURL last == $/ ifFalse: [firstURL _ firstURL, '/'].
	^ firstURL, self versionedFileName
