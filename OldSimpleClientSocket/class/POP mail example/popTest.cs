popTest
	"SimpleClientSocket popTest"

	| addr userName userPassword s msgs header |
	addr _ NetNameResolver promptUserForHostAddress.
	userName _ FillInTheBlank
		request: 'What is your email name?'
		initialAnswer: 'johnm'.
	userPassword _ FillInTheBlank
		request: 'What is your email password?'.

	s _ OldSimpleClientSocket new.
	Transcript show: '---------- Connecting ----------'; cr.
	s connectTo: addr port: 110.  "110 is the POP3 port number"
	s waitForConnectionUntil: self standardDeadline.
	Transcript show: s getResponse.
	s sendCommand: 'USER ', userName.
	Transcript show: s getResponse.
	s sendCommand: 'PASS ', userPassword.
	Transcript show: s getResponse.
	s sendCommand: 'LIST'.

	"the following should be tweaked to handle an empy mailbox:"
	msgs _ self parseIntegerList: s getMultilineResponse.

	1 to: (msgs size min: 5) do: [ :i |
		s sendCommand: 'TOP ', (msgs at: i) printString, ' 0'.
		header _ s getMultilineResponse.
		Transcript show: (self extractDateFromAndSubjectFromHeader: header); cr].

	msgs size > 0 ifTrue: [
		"get the first message"
		s sendCommand: 'RETR 1'.
		Transcript show: s getMultilineResponse].

	Transcript show: 'closing connection'; cr.
	s sendCommand: 'QUIT'.
	s closeAndDestroy.
	Transcript show: '---------- Connection Closed ----------'; cr; endEntry.
