nntpTest
	"SimpleClientSocket nntpTest"

	| addr s headers msgs header allNewsGroups |
	addr _ NetNameResolver promptUserForHostAddress.
	s _ OldSimpleClientSocket new.
	Transcript show: '---------- Connecting ----------'; cr.
	s connectTo: addr port: 119.  "119 is the NNTP port number"
	s waitForConnectionUntil: self standardDeadline.
	Transcript show: s getResponse.
	s sendCommand: 'group comp.lang.smalltalk'.
	Transcript show: s getResponse.

	"get all the message headers for the current newsgroup"
	s sendCommand: 'xover 1-1000000'.
	headers _ s getMultilineResponseShowing: true.

	"print the headers of the first 10 messages of comp.lang.smalltalk"
	s sendCommand: 'listgroup comp.lang.smalltalk'.
	msgs _ self parseIntegerList: s getMultilineResponse.
	msgs ifNotNil: [
		1 to: 5 do: [:i |
			s sendCommand: 'head ', (msgs at: i) printString.
			header _ s getMultilineResponse.
			Transcript show: (self extractDateFromAndSubjectFromHeader: header); cr]].

	"get a full list of usenet newsgroups"
	s sendCommand: 'newgroups 010101 000000'.
	allNewsGroups _ s getMultilineResponse.
	Transcript show: allNewsGroups size printString, ' bytes in full newsgroup list'; cr.

	Transcript show: 'Sending quit...'; cr.
	s sendCommand: 'QUIT'.
	Transcript show: s getResponse.
	s closeAndDestroy.
	Transcript show: '---------- Connection Closed ----------'; cr; endEntry.

	(headers ~~ nil and:
	 [self confirm: 'show article headers from comp.lang.smalltalk?'])
		ifTrue: [
			(StringHolder new contents: (self parseHeaderList: headers))
				openLabel: 'Newsgroup Headers'].

	(allNewsGroups ~~ nil and:
	 [self confirm: 'show list of all newsgroups available on your server?'])
		ifTrue: [
			(StringHolder new contents: allNewsGroups)
				openLabel: 'All Usenet Newsgroups'].
