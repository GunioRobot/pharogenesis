startUp
	
	Preferences enableInternetConfig ifTrue: [
		(SmalltalkImage current platformName =  'Mac OS') ifTrue: [
			 (self getHTTPProxyHost findTokens: ':') ifNotEmpty: [:p |
			 	HTTPSocket useProxyServerNamed: p first port: p second asInteger
		 	]
		]
	]