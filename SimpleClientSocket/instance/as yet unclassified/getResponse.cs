getResponse
	"Get a one-line response from the server.  The final LF is removed from the line, but the CR is left, so that the line is in Squeak's text format"

	^ self getResponseShowing: false
