httpUrlOfServer
	"return the HTTP address to make queries to"	
	#XXX.  "should come up with a better name for this when I'm less tired"
	^HttpUrl schemeName: 'http'  authority: authority  path: path  query: nil.