openFTP
	"Open a connection to the directory and server I hold.  Return a FTPSocket.  It has opened passive, and has a dataPort number assigned to a data FTPSocket.  But the data connection is not open.  When you are done, be sure to tell the socket to QUIT, and then destroy it."

| so resp portInfo list dataPort dd rr |
	(so _ self openNoDataFTP) class == String ifTrue: [^ so].
	so sendCommand: 'TYPE L 8'.
	(rr _ so lookFor: '200 ') == true ifFalse: [socket _ nil.  ^ rr].	"200 Type set to L"

	so sendCommand: 'PASV'.
	resp _ (so getResponseUpTo: FTPSocket crLf) first.
		"Tells which port on server to use for data"
	"Transcript show: resp; cr."
	(resp beginsWith: '227 ') ifFalse: [ "Check for Entering Passive Mode"
		so sendCommand: 'QUIT'.
		so destroy. socket _ nil.
		^ self error: 'can''t get into passive mode'].
	portInfo _ (resp findTokens: '()') at: 2.
	list _ portInfo findTokens: ','.
	dataPort _ (list at: 5) asNumber * 256 + (list at: 6) asNumber.
	dd _ FTPSocket new.
	dd portNum: dataPort.
	so dataSocket: dd.	"save it, not opened yet"
	^ so