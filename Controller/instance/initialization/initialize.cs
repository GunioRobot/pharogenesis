initialize
	"Initialize the state of the receiver. Subclasses should include 'super 
	initialize' when redefining this message to insure proper initialization."
	super initialize.
	sensor := InputSensor default