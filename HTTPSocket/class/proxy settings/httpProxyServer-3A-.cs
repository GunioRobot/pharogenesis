httpProxyServer: aStringOrNil
	| serverName |
	self checkHTTPProxyPreferences.
	serverName := aStringOrNil 
						ifNil: [''] 
						ifNotNil: [aStringOrNil withBlanksTrimmed ].
	Preferences setPreference: #httpProxyServer toValue: serverName