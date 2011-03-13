httpProxyPort: aPortNumber
	self checkHTTPProxyPreferences.
	Preferences setPreference: #httpProxyPort toValue: aPortNumber.