httpProxyServer: aStringOrNil
	| serverName |
	self checkHTTPProxyPreferences.
	serverName _ aStringOrNil 
						ifNil: [''] 
						ifNotNil: [aStringOrNil withBlanksTrimmed ].
	Preferences setPreference: #httpProxyServer toValue: serverName