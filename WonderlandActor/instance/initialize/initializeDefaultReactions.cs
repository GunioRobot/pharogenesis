initializeDefaultReactions
	"Set up our default reactions"
	myReactions _ Dictionary new.
	self respondWith: [:event | self onLeftMouseDown: event] to: leftMouseDown.
	self respondWith: [:event | self onLeftMouseUp: event] to: leftMouseUp.
