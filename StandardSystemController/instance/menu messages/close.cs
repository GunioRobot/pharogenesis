close
	"The receiver's view should be removed from the screen and from the 
	collection of scheduled views."

	model okToChange ifFalse: [^self].
	status := #closed.
	view erase