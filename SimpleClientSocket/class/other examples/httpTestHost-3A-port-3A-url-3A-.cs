httpTestHost: hostName port: port url: url
	"This test fetches a URL from the given host and port."
	"SimpleClientSocket httpTestHost: 'www.disney.com' port: 80 url: '/'"
	"Tests URL fetch through a local HTTP proxie server:
		(SimpleClientSocket
			httpTestHost: '127.0.0.1'
			port: 8080
			url: 'HTTP://www.exploratorium.edu/index.html')"

	| hostAddr s result buf bytes totalBytes t |
	Transcript cr; show: 'starting http test'; cr.
	Socket initializeNetwork.
	hostAddr _ NetNameResolver addressForName: hostName timeout: 10.
	hostAddr = nil ifTrue: [^ self inform: 'Could not find an address for ', hostName].

	s _ SimpleClientSocket new.
	Transcript show: '---------- Connecting ----------'; cr.
	s connectTo: hostAddr port: port.
	s waitForConnectionUntil: "self standardDeadline" (Socket deadlineSecs: 10).
	(s isConnected) ifFalse: [
		s destroy.
		^ self inform: 'could not connect'].
	Transcript show: 'connection open; waiting for data'; cr.

	s sendCommand: 'GET ', url, ' HTTP/1.0'.
	s sendCommand: 'User-Agent: Squeak 1.19'.
	s sendCommand: 'ACCEPT: text/html'.	"always accept plain text"
	s sendCommand: 'ACCEPT: application/octet-stream'.  "also accept binary data"
	s sendCommand: ''.  "blank line"

	result _ WriteStream on: (String new: 10000).
	buf _ String new: 10000.
	totalBytes _ 0.
	t _ Time millisecondsToRun: [
		[s isConnected] whileTrue: [
			s waitForDataUntil: (Socket deadlineSecs: 5).
			bytes _ s receiveDataInto: buf.
			1 to: bytes do: [:i | result nextPut: (buf at: i)].
			totalBytes _ totalBytes + bytes.
			Transcript show: totalBytes printString, ' bytes received'; cr]].

	s destroy.
	Transcript show: '---------- Connection Closed ----------'; cr; endEntry.
	Transcript show: 'http test done; ', totalBytes printString, ' bytes read in '.
	Transcript show: ((t / 1000.0) roundTo: 0.01) printString, ' seconds'; cr.
	Transcript show: ((totalBytes asFloat / t) roundTo: 0.01) printString, ' kBytes/sec'; cr.
	Transcript endEntry.
	(StringHolder new contents: (result contents))
		openLabel: 'HTTP Test Result: URL Contents'.
