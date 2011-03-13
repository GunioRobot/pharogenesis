cancel: characterStream 
	"Cancel unsubmitted changes.  Flushes typeahead.  1/12/96 sw
	 1/22/96 sw: put in control terminate/init"

	self terminateAndInitializeAround: [self cancel].
	^ true