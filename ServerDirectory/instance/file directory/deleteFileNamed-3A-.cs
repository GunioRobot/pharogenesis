deleteFileNamed: fullName
	"Detete a remote file.  fullName is directory path, and does include name of the server.  Or it can just be a fileName."
	| file |
	file _ self asServerFileNamed: fullName.
	file isTypeFile ifTrue: [
		^ (FileDirectory forFileName: (file fileNameRelativeTo: self)) 
			deleteFileNamed: file fileName
	].
	
	client := self openFTPClient.
	[client deleteFileNamed: fullName]
		ensure: [self quit].
