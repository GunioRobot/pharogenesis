putFile: fileStream named: fileNameOnServer
	"Just FTP a local fileStream to the server.  (Later -- Use a proxy server if one has been registered.)"

	| so dd resp rr |
	so _ self openFTP.	"Open passive.  Do everything up to RETR or STOR"
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'STOR ', fileNameOnServer.
	dd _ so dataSocket.

	dd connectTo: so remoteAddress port: dd portNum.
	dd waitForConnectionUntil: FTPSocket standardDeadline.
	Transcript show: 'storing file ', fileNameOnServer; cr.
	"Transcript show: 'store via port ', dd portNum printString; cr."
	dd sendData: fileStream contentsOfEntireFile.
	dd close.

	(rr _ so responseOK) == true ifFalse: [
		(rr beginsWith: '426 ') ifTrue: [socket _ nil.  ^ rr, ' (Server may be full.)'].
			"Connection closed, transfer aborted"
		socket _ nil.  ^ rr].	"150 Opening BINARY mode data connection"
	(resp _ so responseOK) == true ifFalse: [
		socket _ nil.  ^ rr].	"226 Transfer complete."
	socket ifNil: [
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
	dd destroy.

	^ resp	"226 Transfer complete."