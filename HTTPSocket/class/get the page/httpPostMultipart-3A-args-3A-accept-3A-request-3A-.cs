httpPostMultipart: url args: argsDict accept: mimeType request: requestString
	" do multipart/form-data encoding rather than x-www-urlencoded "
	" by Bolot Kerimbaev, 1998 "
	" this version is a memory hog: puts the whole file in memory "

	| serverName serverAddr s header length bare page list firstData aStream port argsStream specifiedServer type newUrl mimeBorder fieldValue |
	Socket initializeNetwork.

	"parse url"
	bare _ (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	serverName _ bare copyUpTo: $/.
	specifiedServer _ serverName.
	(serverName includes: $:) ifFalse: [ port _ self defaultPort ] ifTrue: [
		port _ (serverName copyFrom: (serverName indexOf: $:) + 1 to: serverName size) asNumber.
		serverName _ serverName copyUpTo: $:.
	].

	page _ bare copyFrom: (bare indexOf: $/) to: bare size.
	page size = 0 ifTrue: [page _ '/'].
	HTTPProxyServer ifNotNil: [ 
		page _ 'http://', serverName, ':', port printString, page.		"put back together"
		serverName _ HTTPProxyServer.
		port _ HTTPProxyPort].

	mimeBorder _ '---------squeak-georgia-tech-csl-cool-stuff-----'.
	"encode the arguments dictionary"
	argsStream _ WriteStream on: String new.
	argsStream nextPutAll: mimeBorder, CrLf.
	argsDict associationsDo: [:assoc |
		assoc value do: [ :value |
		" check if it's a non-text field "
		argsStream nextPutAll: 'Content-disposition: form-data; name="', assoc key, '"'.
		(value isKindOf: MIMEDocument)
			ifFalse: [fieldValue _ value]
			ifTrue: [argsStream nextPutAll: ' filename="', value url pathForFile, '"', CrLf, 'Content-Type: ', value contentType.
				fieldValue _ (value content
					ifNil: [(FileStream fileNamed: value url pathForFile) contentsOfEntireFile]
					ifNotNil: [value content]) asString].
" Transcript show: 'field=', key, '; value=', fieldValue; cr. "
		argsStream nextPutAll: CrLf, CrLf, fieldValue, CrLf, CrLf, mimeBorder, CrLf.
	]].

  	"make the request"	
	self retry: [serverAddr _ NetNameResolver addressForName: serverName timeout: 20.
				serverAddr ~~ nil] 
		asking: 'Trouble resolving server name.  Keep trying?'
		ifGiveUp: [^ 'Could not resolve the server named: ', serverName].


	s _ HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionUntil: self standardDeadline.
	Transcript cr; show: serverName, ':', port asString; cr.
	s sendCommand: 'POST ', page, ' HTTP/1.1', CrLf, 
		(mimeType ifNotNil: ['ACCEPT: ', mimeType, CrLf] ifNil: ['']),
		'ACCEPT: text/html', CrLf,	"Always accept plain text"
		HTTPBlabEmail,	"may be empty"
		requestString,	"extra user request. Authorization"
		'User-Agent: Squeak 1.31', CrLf,
		'Content-type: multipart/form-data; boundary=', mimeBorder, CrLf,
		'Content-length: ', argsStream contents size printString, CrLf,
		'Host: ', specifiedServer, CrLf.  "blank line automatically added"

	s sendCommand: argsStream contents.

	"get the header of the reply"
	list _ s getResponseUpTo: CrLf, CrLf.	"list = header, CrLf, CrLf, beginningOfData"
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