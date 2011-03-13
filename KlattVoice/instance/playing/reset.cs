reset
	"Reset the state of the receiver."
	super reset.
	lastEvent := lastEventTime := nil.
	current := right := left := self segments end