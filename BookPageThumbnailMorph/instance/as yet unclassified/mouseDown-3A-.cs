mouseDown: event
	"turn the book to that page"

	event setButtons: 0.	"Lie to it.  So mouseUp won't go to menu that may come up 
		during fetch of a page in doPageFlip"
	self doPageFlip.
