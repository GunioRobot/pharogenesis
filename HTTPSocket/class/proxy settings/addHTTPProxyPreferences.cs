addHTTPProxyPreferences
	" This method will add to Squeak the HTTP Proxy preferences. "
	Preferences addTextPreference: #httpProxyServer category: #'http proxy'  default: '' balloonHelp: 'HTTP Proxy Server. Leave blank if you don''t want to use a Proxy'.
	Preferences addNumericPreference: #httpProxyPort  category:  #'http proxy' default: 80 balloonHelp: 'HTTP Proxy Port'.