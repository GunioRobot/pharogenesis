initialize
	"Initialize the receiver"
	super initialize.
	eventQueue := SharedQueue new.
	mouseButtons := 0.
	mousePosition := 0 @ 0