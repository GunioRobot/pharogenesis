versionFrom: aServerFile
	| theName uu serverUrl |
	"Store the version of the file I actually came from.  My stored version was recorded before I knew the latest version number on the server!"

	(aServerFile class == String) 
		ifTrue: [uu _ aServerFile asUrl.
				theName _ uu path last.
				serverUrl _ (uu toText copyUpToLast: $/), '/']
		ifFalse: [serverUrl _ aServerFile directoryUrl.
				theName _ aServerFile localName].
	version _ (theName findTokens: '|.') second.
	(serverUrl beginsWith: 'ftp:') ifTrue: ["update our server location"
		urlList ifNil: [urlList _ Array new: 1].
		urlList size = 0 ifTrue: [urlList _ Array new: 1].
		urlList at: 1 put: serverUrl].
