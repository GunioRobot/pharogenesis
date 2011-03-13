httpProxyPort
	"answer the httpProxyPort"
	self checkHTTPProxyPreferences.
	^Preferences valueOfPreference: #httpProxyPort.