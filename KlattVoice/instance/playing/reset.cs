reset
	"Reset the state of the receiver."
	super reset.
	lastEvent _ lastEventTime _ nil.
	current _ right _ left _ self segments end