versionFrom: aServerFile
	"Store the version of the file I actually came from.  My stored version was recorded before I knew the latest version number on the server!"
	| theName serverUrl |

	self flag: #bob.		"this may become unnecessary once we get the version before writing"
	self flag: #bob.		"need to recognize swiki servers"

	serverUrl _ aServerFile directoryUrl.
	theName _ aServerFile localName.
	version _ (Project parseProjectFileName: theName) second.
	(serverUrl beginsWith: 'ftp:') ifTrue: ["update our server location"
		self storeNewPrimaryURL: serverUrl
	].
