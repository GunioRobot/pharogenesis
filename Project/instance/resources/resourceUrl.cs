resourceUrl
	"compose my base url for resources on the server"
	| firstURL | 
"
	primaryServer _ self primaryServerIfNil: [^''].
	firstURL _ primaryServer altUrl ifNil: [primaryServer url]."
	firstURL _ self downloadUrl.
	firstURL isEmpty
		ifFalse: [firstURL last == $/ ifFalse: [firstURL _ firstURL, '/']].
	^ firstURL, self resourceDirectoryName , '/'
