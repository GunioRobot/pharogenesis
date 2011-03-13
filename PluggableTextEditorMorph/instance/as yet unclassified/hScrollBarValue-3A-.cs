hScrollBarValue: scrollValue
	"Trigger an event too."
	
	super hScrollBarValue: scrollValue.
	self triggerEvent: #hScroll with: scrollValue