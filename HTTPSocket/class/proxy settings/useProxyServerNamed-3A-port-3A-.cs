useProxyServerNamed: proxyServerName port: portNum
	"Direct all HTTP requests to the HTTP proxy server with the given name and port number."

	proxyServerName ifNil: [  "clear proxy settings"
		HTTPProxyServer _ nil.
		HTTPProxyPort _ 80.
		^ self].

	proxyServerName class == String
		ifFalse: [self error: 'Server name must be a String or nil'].
	HTTPProxyServer _ proxyServerName.

	HTTPProxyPort _ portNum.
	HTTPProxyPort class == String ifTrue: [HTTPProxyPort _ portNum asNumber].
	HTTPProxyPort ifNil: [HTTPProxyPort _ self defaultPort].