getFileNamed: fileNameOnServer into: dataStream
	"Just FTP a file from a server.  Return a stream.  (Later -- Use a proxy server if one has been registered.)"

	| so dd resp rr |
	type == #file ifTrue: [
		dataStream nextPutAll: 
			(resp _ FileStream oldFileNamed: server,(self serverDelimiter asString), 
				self bareDirectory, (self serverDelimiter asString),
				fileNameOnServer) contentsOfEntireFile.
		dataStream dataIsValid.
		^ resp].
	type == #http ifTrue: [
		resp _ HTTPSocket httpGet: (self fullNameFor: fileNameOnServer) 
				accept: 'application/octet-stream'.
		resp class == String ifTrue: [^ dataStream].	"error, no data"
		dataStream copyFrom: resp.
		dataStream dataIsValid.
		^ dataStream].
	type ifNil: [type _ #ftp].
	"type == #ftp"
	so _ self openFTP.	"Open passive.  Do everything up to RETR or STOR"
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'RETR ', fileNameOnServer.
	dd _ so dataSocket.

	dd connectTo: so remoteAddress port: dd portNum.
	dd waitForConnectionUntil: FTPSocket standardDeadline.
	Transcript show: 'retrieving file ', fileNameOnServer; cr.
	"Transcript show: 'retrieve from port ', dd portNum printString; cr."
	resp _ dd getDataTo: dataStream whileWatching: so.
		"Later use the length to pre-allocate the buffer"
	(resp == #error:) ifTrue: [socket _ nil.  ^ resp].
	dd close.

	(rr _ so responseOK) == true ifFalse: [
		socket _ nil.  ^ rr].	"150 Opening binary conn on foo (3113 bytes)"
	(rr _ so responseOK) == true ifFalse: [
		socket _ nil.  ^ rr].	"226 Transfer complete."
	socket ifNil: ["normally leave connection open.  Don't quit"
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
	dd destroy.

	dataStream dataIsValid.
	^ resp	"String with just the data"