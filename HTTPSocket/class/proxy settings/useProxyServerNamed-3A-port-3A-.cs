useProxyServerNamed: proxyServerName port: portNum
	"Direct all HTTP requests to the HTTP proxy server with the given name and port number."

	proxyServerName ifNil: [  "clear proxy settings"
		HTTPProxy _ nil.
		HTTPPort _ 80.
		^ self].

	proxyServerName class == String
		ifFalse: [self error: 'Server name must be a String or nil'].
	HTTPProxy _ proxyServerName.

	HTTPPort _ portNum.
	HTTPPort class == String ifTrue: [HTTPPort _ portNum asNumber].
	HTTPPort ifNil: [HTTPPort _ 80].
