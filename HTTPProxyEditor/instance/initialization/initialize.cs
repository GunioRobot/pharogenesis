initialize
	"initialize the receiver"
	super initialize.
	""
	serverName := HTTPSocket httpProxyServer
				ifNil: [''].
	port := HTTPSocket httpProxyPort asString.
	""
	self setLabel: 'HTTP Proxy Editor' translated.
	self
		setWindowColor: (Color
				r: 0.9
				g: 0.8
				b: 1.0).
	""
	self initializeWidgets.
	self updateWidgets.
""
self extent: 300@180