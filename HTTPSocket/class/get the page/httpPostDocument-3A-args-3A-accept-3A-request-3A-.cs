httpPostDocument: url  args: argsDict accept: mimeType request: requestString
	"like httpGET, except it does a POST instead of a GET.  POST allows data to be uploaded"

	| serverName serverAddr s header length bare page list firstData aStream port argsStream first specifiedServer type newUrl |
	Socket initializeNetwork.

	"parse url"
	bare _ (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	serverName _ bare copyUpTo: $/.
	specifiedServer _ serverName.
	(serverName includes: $:) ifFalse: [ port _ self defaultPort ] ifTrue: [
		port _ (serverName copyFrom: (serverName indexOf: $:) + 1 
				to: serverName size) asNumber.
		serverName _ serverName copyUpTo: $:.
	].

	page _ bare copyFrom: (bare indexOf: $/) to: bare size.
	page size = 0 ifTrue: [page _ '/'].
	HTTPProxyServer ifNotNil: [ 
		page _ 'http://', serverName, ':', port printString, page.		"put back together"
		serverName _ HTTPProxyServer.
		port _ HTTPProxyPort].

	"encode the arguments dictionary"
	argsStream _ WriteStream on: String new.
	first _ true.
	argsDict associationsDo: [ :assoc |
		assoc value do: [ :value |
			first ifTrue: [ first _ false ] ifFalse: [ argsStream nextPut: $& ].
			argsStream nextPutAll: assoc key encodeForHTTP.
			argsStream nextPut: $=.
			argsStream nextPutAll: value encodeForHTTP.
	] ].

  	"make the request"	
	self retry: [serverAddr _ NetNameResolver addressForName: serverName timeout: 20.
				serverAddr ~~ nil] 
		asking: 'Trouble resolving server name.  Keep trying?'
		ifGiveUp: [^ 'Could not resolve the server named: ', serverName].

	s _ HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionUntil: self standardDeadline.
	Transcript cr; show: url; cr.
	s sendCommand: 'POST ', page, ' HTTP/1.0', CrLf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, CrLf] ifNil: ['']),
		'ACCEPT: text/html', CrLf,	"Always accept plain text"
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		'User-Agent: Squeak 1.31', CrLf,
		'Content-type: application/x-www-form-urlencoded', CrLf,
		'Content-length: ', argsStream contents size printString, CrLf,
		'Host: ', specifiedServer, CrLf.  "blank line automatically added"

	s sendCommand: argsStream contents.

	"get the header of the reply"
	list _ s getResponseUpTo: CrLf, CrLf ignoring: (String with: CR).	"list = header, CrLf, CrLf, beginningOfData"
	header _ list at: 1.
	"Transcript show: page; cr; show: argsStream contents; cr; show: header; cr."
	firstData _ list at: 3.

	"dig out some headers"
	s header: header.
	length _ s getHeader: 'content-length'.
	length ifNotNil: [ length _ length asNumber ].
	type _ s getHeader: 'content-type'.
	s responseCode first = $3 ifTrue: [
		newUrl _ s getHeader: 'location'.
		newUrl ifNotNil: [
			Transcript show: 'redirecting to: ', newUrl; cr.
			s destroy.
			^self httpPostDocument: newUrl  args: argsDict  accept: mimeType ] ].

	aStream _ s getRestOfBuffer: firstData totalLength: length.
	s responseCode = '401' ifTrue: [^ header, aStream contents].
	s destroy.	"Always OK to destroy!"

	^ MIMEDocument contentType: type  content: aStream contents url: url