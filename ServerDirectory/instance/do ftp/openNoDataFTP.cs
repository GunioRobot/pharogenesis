openNoDataFTP
	"Open a connection to the directory and server I hold.  Return a FTPSocket.  No dataPort is opened.  When you are all done, be sure to tell the socket to QUIT, and then destroy it."

	| so rr serverIP what |
	Socket initializeNetwork.
	socket ifNotNil: [socket isValid 
			ifTrue: [^ socket]	"already open"
			ifFalse: [socket _ nil]].

	Cursor wait showWhile: [
		FTPSocket retry: [serverIP _ NetNameResolver addressForName: server timeout: 20.
					serverIP ~~ nil] 
			asking: 'Trouble resolving server name.  Keep trying?'
			ifGiveUp: [^ 'Could not resolve the server named: ', server].
		so _ FTPSocket new.
		so portNum: 21.
		so connectTo: serverIP port: 21.  "21 is for the control connection"
		so waitForConnectionUntil: FTPSocket standardDeadline.
		].

	Transcript cr; show: 'ftp: ', server; cr.
	(rr _ so lookFor: '220 ') == true ifFalse: [^ rr].	"220 para1 Microsoft FTP Service"
	so sendCommand: 'USER ', user.
	(rr _ so lookFor: '331 ') == true ifFalse: [^ rr].	"331 Password required"
	[so sendCommand: 'PASS ', self password.		"will ask user, if needed"
	 (rr _ so lookSoftlyFor: '230 ') == true] 	"230 User logged in"
		whileFalse: [
			rr first == $5 ifFalse: [^ rr].	"timeout"
			passwordHolder _ nil.
			what _ (PopUpMenu labels: 'enter password\give up' withCRs) 
				startUpWithCaption: 'Would you like to try another password?'.
			what = 1 ifFalse: [so destroy.  ^ rr]].
	so sendCommand: 'CWD ', directory.
	(rr _ so lookFor: '250 ') == true ifFalse: [^ rr].	"250 CWD successful"
	"Need to ask for name of directory to make sure?"
	"socket _ so".	"If user wants to keep connnection open, he must store socket"
	^ so