initialize
	"URI initialize"

	ClientClasses _ Dictionary new.
	ClientClasses
		at: 'http' put: #HTTPClient;
		at: 'ftp' put: #FTPClient;
		at: 'file' put: #FileDirectory
