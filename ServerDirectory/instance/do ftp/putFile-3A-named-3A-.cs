putFile: fileStream named: fileNameOnServer
	"Just FTP a local fileStream to the server.  (Later -- Use a proxy server if one has been registered.)"

	| so dd resp rr |
	so _ self openFTP.	"Open passive.  Do everything up to RETR or STOR"
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'STOR ', fileNameOnServer.
	dd _ so dataSocket.

	dd connectTo: so remoteAddress port: dd portNum.
	dd waitForConnectionUntil: FTPSocket standardDeadline.
	Transcript show: 'store via port ', dd portNum printString; cr.
	dd sendData: fileStream contentsOfEntireFile.
	dd close.

	(rr _ so responseOK) == true ifFalse: [^ rr].	"150 Opening binary conn on foo (3113 bytes)"
	(resp _ so responseOK) == true ifFalse: [^ rr].	"226 Transfer complete."
	so sendCommand: 'QUIT'.
	(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
	so destroy.	"Always OK to destroy"
	dd destroy.

	^ resp	"226 Transfer complete."