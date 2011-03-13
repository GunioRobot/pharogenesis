shouldUseProxy: serverName
	"Retrieve the server and port information from the URL, match it to the proxy settings and open a http socket for the request."

	HTTPProxyServer ifNotNil: [
		self httpProxyExceptions
			detect: [:domainName | domainName match: serverName]
			ifNone: [^true]].
	^false
