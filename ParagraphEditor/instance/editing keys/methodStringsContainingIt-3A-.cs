methodStringsContainingIt: characterStream 
	"Invoked from cmd-E -- open a browser on all methods holding string constants containing it.  Flushes typeahead. "

	sensor keyboard.	
	self methodStringsContainingit.
	^ true