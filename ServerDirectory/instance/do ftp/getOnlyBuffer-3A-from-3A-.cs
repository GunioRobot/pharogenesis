getOnlyBuffer: buffer from: fileNameOnServer
	"Open ftp, fill the buffer, and close the connection.  Only first part of a very long file."
	| so dd resp rr |

	"type == #ftp"
	so _ self openFTP.	"Open passive.  Do everything up to RETR or STOR"
	so class == String ifTrue: ["error, was reported" ^ so].
	so sendCommand: 'RETR ', fileNameOnServer.
	dd _ so dataSocket.

	dd connectTo: so remoteAddress port: dd portNum.
	dd waitForConnectionUntil: FTPSocket standardDeadline.
	Transcript show: 'retrieving beginning of file ', fileNameOnServer; cr.
	resp _ dd getOnlyBuffer: buffer whileWatching: so.
	(resp == #error:) ifTrue: [socket _ nil.  ^ resp].

	(rr _ so responseOK) == true ifFalse: [
		socket _ nil.  ^ rr].	"150 Opening binary conn on foo (3113 bytes)"
	dd destroy.
	so sendCommand: 'ABOR'.
	socket _ nil.
	so destroy.	"Just be as rude as possible"

	^ resp	"String with just the data"