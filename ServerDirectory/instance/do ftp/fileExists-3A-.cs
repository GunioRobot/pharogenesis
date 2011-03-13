fileExists: fileName
	"Does the file exist on this server directory?  fileName must be simple with no / or references to other directories."

	self isTypeFile ifTrue: [^ self fileNames includes: fileName].
	self isTypeHTTP ifTrue: [^ (self readOnlyFileNamed: fileName) class ~~ String].
	"ftp"
	^ (self getFileList contentsOfEntireFile findTokens: FTPSocket crLf) includes: fileName