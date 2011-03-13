reset
	"Initialize the receiver to act just as a FormCanvas"
	super reset.
	foundMorph _ false.
	doStop _ false.
	stopMorph _ nil.