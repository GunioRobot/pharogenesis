getMultilineResponse
	"Get a multiple line response to the last command, filtering out LF characters. A multiple line response ends with a line containing only a single period (.) character."

	^ self getMultilineResponseShowing: false.
