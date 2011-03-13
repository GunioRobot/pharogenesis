initHTTPSocket: httpUrl ifError: aBlock
	"Retrieve the server and port information from the URL, match it to the proxy settings and open a http socket for the request."

	^self initHTTPSocket: httpUrl wait: self standardDeadline ifError: aBlock