flash: aRectangle 
	"Flash the area of the screen defined by the given rectangle."

	self reverse: aRectangle.
	(Delay forMilliseconds: 100) wait.
	self reverse: aRectangle.
