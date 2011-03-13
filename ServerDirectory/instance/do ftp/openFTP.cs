openFTP
	"Open a connection to the directory and server I hold.  Return a FTPSocket.  It has opened passive, and has a dataPort number assigned to a data FTPSocket.  But the data connection is not open.  When you are done, be sure to tell the socket to QUIT, and then destroy it."

	| so resp portInfo list dataPort dd rr serverIP |
	Socket initializeNetwork.
	FTPSocket retry: [serverIP _ NetNameResolver addressForName: server timeout: 20.
				serverIP ~~ nil] 
		asking: 'Trouble resolving server name.  Keep trying?'
		ifGiveUp: [^ 'Could not resolve the server named: ', server].
	so _ FTPSocket new.
	so portNum: 21.
	so connectTo: serverIP port: 21.  "21 is for the control connection"
	so waitForConnectionUntil: FTPSocket standardDeadline.

	Transcript cr; show: server; cr.
	(rr _ so lookFor: '220 ') == true ifFalse: [^ rr].	"220 para1 Microsoft FTP Service"
	so sendCommand: 'USER ', user.
	(rr _ so lookFor: '331 ') == true ifFalse: [^ rr].	"331 Password required"
	so sendCommand: 'PASS ', self password.
	(rr _ so lookFor: '230 ') == true ifFalse: [^ rr].	"230 User logged in"
	so sendCommand: 'CWD ', directory.
	(rr _ so lookFor: '250 ') == true ifFalse: [^ rr].	"250 CWD successful"
	"Need to ask for name of directory to make sure?"
	so sendCommand: 'TYPE L 8'.
	(rr _ so lookFor: '200 ') == true ifFalse: [^ rr].	"200 Type set to L"
	so sendCommand: 'PASV'.
	resp _ (so getResponseUpTo: FTPSocket crLf) first.
		"Tells which port on server to use for data"
	Transcript show: resp; cr.
	(resp beginsWith: '227 Entering Passive Mode (') ifFalse: [
		so sendCommand: 'QUIT'.
		so destroy.
		^ self error: 'can''t get into passive mode'].
	portInfo _ (resp findTokens: '()') at: 2.
	list _ portInfo findTokens: ','.
	dataPort _ (list at: 5) asNumber * 256 + (list at: 6) asNumber.
	dd _ FTPSocket new.
	dd portNum: dataPort.
	so dataSocket: dd.	"save it, not opened yet"
	^ so