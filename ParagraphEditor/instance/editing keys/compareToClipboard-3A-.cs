compareToClipboard: characterStream 
	"Compare the receiver to the text on the clipboard.  Flushes typeahead.  5/1/96 sw"

	sensor keyboard.	
	self terminateAndInitializeAround: [self compareToClipboard].
	^ true