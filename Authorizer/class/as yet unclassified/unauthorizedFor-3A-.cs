unauthorizedFor: realm
	^'HTTP/1.0 401 Unauthorized', self crlf, 'WWW-Authenticate: Basic realm="Squeak/',realm,'"',
	String crlfcrlf, '<html><title>Unauthorized</title><body><h2>Unauthorized for ',realm, '</h2></body></html>'

