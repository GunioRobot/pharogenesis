finger: userName
	"SimpleClientSocket finger: 'stp'"

	| addr s |
	addr _ NetNameResolver promptUserForHostAddress.
	s _ SimpleClientSocket new.
	Transcript show: '---------- Connecting ----------'; cr.
	s connectTo: addr port: 79.  "finger port number"
	s waitForConnectionUntil: self standardDeadline.
	s sendCommand: userName.
	Transcript show: s getResponse.
	s closeAndDestroy.
	Transcript show: '---------- Connection Closed ----------'; cr; endEntry.
