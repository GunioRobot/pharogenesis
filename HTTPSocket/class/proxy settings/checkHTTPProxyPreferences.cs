checkHTTPProxyPreferences
	Preferences preferenceAt: #httpProxyPort ifAbsent: [self addHTTPProxyPreferences].
	Preferences preferenceAt: #httpProxyServer ifAbsent: [self addHTTPProxyPreferences].