timeTest
	"SimpleClientSocket timeTest"

	| addr s |
	addr _ NetNameResolver promptUserForHostAddress.
	s _ OldSimpleClientSocket new.
	Transcript show: '---------- Connecting ----------'; cr.
	s connectTo: addr port: 13.  "time port number"
	s waitForConnectionUntil: self standardDeadline.
	Transcript show: s getResponse.
	s closeAndDestroy.
	Transcript show: '---------- Connection Closed ----------'; cr; endEntry.
