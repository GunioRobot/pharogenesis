httpGet: url accept: mimeType
	"Return the exact contents of a web object. Asks for the given MIME type. If mimeType is nil, use 'text/html'. The parsed header is saved. Use a proxy server if one has been registered.  tk 7/23/97 17:12"
	"Note: To fetch raw data, you can use the MIMI type 'application/octet-stream'."

	| serverName serverAddr s header length bare page list firstData aStream newURL |
	Socket initializeNetwork.
	bare _ (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	"For now, may not put :80 or other port number in a url.  Use setHTTPPort:"
	serverName _ bare copyUpTo: $/.
	page _ bare copyFrom: serverName size + 1 to: bare size.
	page size = 0 ifTrue: [page _ '/'].
	HTTPProxy ifNotNil: [
		page _ 'http://', serverName, page.		"put back together"
		serverName _ HTTPProxy].
	
	self retry: [serverAddr _ NetNameResolver addressForName: serverName timeout: 20.
				serverAddr ~~ nil] 
		asking: 'Trouble resolving server name.  Keep trying?'
		ifGiveUp: [^ 'Could not resolve the server named: ', serverName].

	s _ HTTPSocket new.
	s connectTo: serverAddr port: HTTPPort.  "80 is normal"
	s waitForConnectionUntil: self standardDeadline.
	Transcript cr; show: serverName; cr.
	s sendCommand: 'GET ', page, ' HTTP/1.0', CrLf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, CrLf] ifNil: ['']),
		'ACCEPT: text/html', CrLf,	"Always accept plain text"
		HTTPBlabEmail,	"may be empty"
		'User-Agent: Squeak 1.31', 
		CrLf.	"blank line"
	list _ s getResponseUpTo: CrLf, CrLf.	"list = header, CrLf, CrLf, beginningOfData"
	header _ list at: 1.
	Transcript show: page; cr; show: header; cr.
	firstData _ list at: 3.

	"Find the length"
	length _ s contentsLength: header.	"saves the headerTokens"
	length ifNil: [
		(newURL _ s redirect) ifNotNil: [^ self httpGet: newURL accept: mimeType].
		Transcript cr; show: 'Some kind of Error'.
		s destroy.   ^ header].
	
	aStream _ s getRestOfBuffer: firstData totalLength: length.
	s destroy.	"Always OK to destroy!"

	^ aStream	"String with just the data"