fileExists: fileName
	"Does the file exist on this server directory?  fileName must be simple with no / or references to other directories."

	type == #file ifTrue: [^ self fileNames includes: fileName].
	type == #http ifTrue: [^ (self readOnlyFileNamed: fileName) class ~~ String].
	"ftp"
	^ (self getFileList contentsOfEntireFile findTokens: FTPSocket crLf) includes: fileName