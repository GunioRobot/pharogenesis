getFileNamed: fileNameOnServer into: dataStream httpRequest: requestString
	"Just FTP a file from a server.  Return a stream.  (Later -- Use a proxy server if one has been registered.)"

	| resp |
	self isTypeFile ifTrue: [
		dataStream nextPutAll: 
			(resp _ FileStream oldFileNamed: server,(self serverDelimiter asString), 
				self bareDirectory, (self serverDelimiter asString),
				fileNameOnServer) contentsOfEntireFile.
		dataStream dataIsValid.
		^ resp].
	self isTypeHTTP ifTrue: [
		resp _ HTTPSocket httpGet: (self fullNameFor: fileNameOnServer) 
				args: nil accept: 'application/octet-stream' request: requestString.
		resp class == String ifTrue: [^ dataStream].	"error, no data"
		dataStream copyFrom: resp.
		dataStream dataIsValid.
		^ dataStream].

	client _ self openFTPClient.	"Open passive.  Do everything up to RETR or STOR"
	[client getFileNamed: fileNameOnServer into: dataStream]
		ensure: [self quit].

	dataStream dataIsValid.
