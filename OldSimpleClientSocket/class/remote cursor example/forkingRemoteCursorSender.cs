forkingRemoteCursorSender
	"This is the client side of a test that sends samples of the local input sensor state to the server, which may be running on a local or remote host. This method opens the connection, then forks a process to send the cursor data. Data is sent continuously until the user clicks in a 20x20 pixel square at the top-left corner of the display. The server should be started first. Note the server's address, since this method will prompt you for it."
	"SimpleClientSocket forkingRemoteCursorSender"

	| sock addr stopRect |
	Transcript show: 'starting remote cursor sender'; cr.
	Transcript show: 'initializing network'; cr.
	Socket initializeNetwork.
	addr _ NetNameResolver promptUserForHostAddress.
	Transcript show: 'opening connection'; cr.
	sock _ OldSimpleClientSocket new.
	sock connectTo: addr port: 54323.
	sock waitForConnectionUntil: self standardDeadline.
	(sock isConnected) ifFalse: [self error: 'sock not connected'].
	Transcript show: 'connection established'; cr.

	stopRect _ 0@0 corner: 20@20.  "click in this rectangle to stop sending"
	Display reverse: stopRect.
	["the sending process"
		[(stopRect containsPoint: Sensor cursorPoint) and:
		 [Sensor anyButtonPressed]]
			whileFalse: [
				sock sendCommand: self sensorStateString.
				(Delay forMilliseconds: 20) wait].

		sock waitForSendDoneUntil: self standardDeadline.
		sock destroy.
		Transcript show: 'remote cursor sender done'; cr.
		Display reverse: stopRect.
	] fork.
