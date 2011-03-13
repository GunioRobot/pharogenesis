httpProxyServer
	"answer the httpProxyServer. Take into account that as a Preference the Server might appear as an empty string but HTTPSocket expect it to be nil"
	self checkHTTPProxyPreferences.
	^Preferences valueOfPreference: #httpProxyServer.
