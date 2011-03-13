getFileNamed: fileNameOnServer
	"Just FTP a file from a server.  Return a stream.  (Later -- Use a proxy server if one has been registered.)"

	| so dd resp rr |
	so _ self openFTP.	"Open passive.  Do everything up to RETR or STOR"
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'RETR ', fileNameOnServer.
	dd _ so dataSocket.

	dd connectTo: so remoteAddress port: dd portNum.
	dd waitForConnectionUntil: FTPSocket standardDeadline.
	Transcript show: 'retrieve from port ', dd portNum printString; space;
		show: fileNameOnServer; cr.
	resp _ dd getAllDataWhileWatching: so.	"Later use the length to pre-allocate the buffer"
	(resp == #error:) ifTrue: [^ resp].
	dd close.

	(rr _ so responseOK) == true ifFalse: [^ rr].	"150 Opening binary conn on foo (3113 bytes)"
	(rr _ so responseOK) == true ifFalse: [^ rr].	"226 Transfer complete."
	so sendCommand: 'QUIT'.
	(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
	so destroy.	"Always OK to destroy"
	dd destroy.

	^ resp	"String with just the data"