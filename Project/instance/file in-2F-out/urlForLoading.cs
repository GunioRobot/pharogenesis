urlForLoading
	"compose a url that will load me in someone's browser"
	| myServer serverList myUrl downloadUrl |
	serverList _ self serverList.
	serverList isEmptyOrNil
		ifTrue: [
			urlList isEmptyOrNil ifTrue: [^nil].
			downloadUrl _ urlList first asUrl downloadUrl]
		ifFalse: [
			myServer _ serverList first.
			myUrl _ myServer altUrl.
			myUrl last == $/
				ifFalse: [myUrl _ myUrl , '/'].
			downloadUrl _ myUrl].
	^downloadUrl , (self name, FileDirectory dot,'html') encodeForHTTP
