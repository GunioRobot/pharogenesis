getFileList
	"Return a stream with a list of files in the current server directory.  (Later -- Use a proxy server if one has been registered.)"

	| so dd resp rr |
	so _ self openFTP.	"Open passive.  Do everything up to RETR or STOR"
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'NLST'.
	dd _ so dataSocket.

	dd connectTo: so remoteAddress port: dd portNum.
	dd waitForConnectionUntil: FTPSocket standardDeadline.
	Transcript show: 'getting file list NLST'; cr.
	"Transcript show: 'retrieve from port ', dd portNum printString; cr."
	resp _ dd getAllDataWhileWatching: so.	"Later use the length to pre-allocate the buffer"
	(resp == #error:) ifTrue: [socket _ nil.  ^ resp].
	dd close.

	(rr _ so responseOK) == true ifFalse: [
		socket _ nil.  ^ rr].	"150 Opening binary conn on foo (3113 bytes)"
	(rr _ so responseOK) == true ifFalse: [
		socket _ nil.  ^ rr].	"226 Transfer complete."
	socket ifNil: [
		so sendCommand: 'QUIT'.
		(rr _ so responseOK) == true ifFalse: [^ rr].	"221"
		so destroy].	"Always OK to destroy"
	dd destroy.

	^ resp	"RWStream with just the data"