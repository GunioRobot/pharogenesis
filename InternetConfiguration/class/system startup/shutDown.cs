shutDown
	Preferences enableInternetConfig ifTrue: [
		(SmalltalkImage current platformName =  'Mac OS') ifTrue: [
	  		HTTPSocket stopUsingProxyServer.
		]
	]. 
