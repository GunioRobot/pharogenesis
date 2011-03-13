vScrollBarValue: scrollValue
	"Trigger an event too."
	
	super vScrollBarValue: scrollValue.
	self triggerEvent: #vScroll with: scrollValue