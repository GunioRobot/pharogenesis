setProxyIfInDOL
	"Test to see if we are inside DOL.  If so, set the proxy server."

| me myNet |
NetNameResolver initializeNetwork.
NetNameResolver addressForName: 'www.disney.com' timeout: 5.
	"Just to make sure the ISND line is started"
me _ NetNameResolver localHostAddress.
myNet _ (me copyFrom: 1 to: 3) asArray.
#( (204 128 192) (206 18 91) ) do: [:dolNet |
		myNet = dolNet ifTrue: ["We are inside DOL"
			^ self useProxyServerNamed: 'web-proxy.online.disney.com' port: 8080]].
"We are not inside DOL"
HTTPProxy = 'web-proxy.online.disney.com' ifTrue: [
	"No longer there, stop the proxy"
	^ self stopUsingProxyServer].
