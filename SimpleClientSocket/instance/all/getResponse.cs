getResponse
	"Get the response to the last command, filtering out LF characters."

	^ self getResponseShowing: false
