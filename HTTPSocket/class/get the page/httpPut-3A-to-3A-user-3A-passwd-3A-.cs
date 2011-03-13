httpPut: contents to: url user: user passwd: passwd
	"Upload the contents of the stream to a file on the server"

	| bare serverName specifiedServer port page serverAddr authorization s list header firstData length aStream command digest |
	Socket initializeNetwork.
 
	"parse url"
	bare := (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	serverName := bare copyUpTo: $/.
	specifiedServer := serverName.
	(serverName includes: $:) ifFalse: [ port := self defaultPort ] ifTrue: [
		port := (serverName copyFrom: (serverName indexOf: $:) + 1 
				to: serverName size) asNumber.
		serverName := serverName copyUpTo: $:.
	].

	page := bare copyFrom: (bare indexOf: $/) to: bare size.
	page size = 0 ifTrue: [page := '/'].
	(self shouldUseProxy: serverName) ifTrue: [ 
		page := 'http://', serverName, ':', port printString, page.		"put back together"
		serverName := self httpProxyServer.
		port := self httpProxyPort].

  	"make the request"	
	serverAddr := NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		^ 'Could not resolve the server named: ', serverName].

	authorization := ' Basic ', (Base64MimeConverter mimeEncode: (user , ':' , passwd) readStream) contents.
[
	s := HTTPSocket new.
	s connectTo: serverAddr port: port.
	s waitForConnectionFor: self standardTimeout.
	Transcript cr; show: url; cr.
	command := 
		'PUT ', page, ' HTTP/1.0', String crlf, 
		self userAgentString, String crlf,
		'Host: ', specifiedServer, String crlf, 
		'ACCEPT: */*', String crlf,
		HTTPProxyCredentials,
		'Authorization: ' , authorization , String crlf , 
		'Content-length: ', contents size printString, String crlf , String crlf , 
		contents.
	s sendCommand: command.
	"get the header of the reply"
	list := s getResponseUpTo: String crlf, String crlf ignoring: String cr.	"list = header, CrLf, CrLf, beginningOfData"
	header := list at: 1.
	"Transcript show: page; cr; show: argsStream contents; cr; show: header; cr."
	firstData := list at: 3.

	"dig out some headers"
	s header: header.

(authorization beginsWith: 'Digest ') not
and: [(digest := self digestFrom: s method: 'PUT' url: url user: user password: passwd) notNil]]
	whileTrue: [authorization :=  'Digest ', digest].

	length := s getHeader: 'content-length'.
	length ifNotNil: [ length := length asNumber ].

	aStream := s getRestOfBuffer: firstData totalLength: length.
	s destroy.	"Always OK to destroy!"
	^ header, aStream contents