fileExists: fileName
	"Does the file exist on this server directory?  fileName must be simple with no / or references to other directories."

	^ (self getFileList contentsOfEntireFile findTokens: FTPSocket crLf) includes: fileName