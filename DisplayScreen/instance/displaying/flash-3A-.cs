flash: aRectangle 
	"Complement twice the area of the screen defined by the argument, 
	aRectangle."

	2 timesRepeat:
		[self reverse: aRectangle.
		"(Delay forMilliseconds: 30) wait"]