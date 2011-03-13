processShutDownList
	"Call the shutDown method on each object that needs to gracefully shut itself down before a snapshot."

	SoundPlayer shutDown.
	Smalltalk shutDown.
	Delay shutDown.
	ControlManager shutDown.
	DisplayScreen shutDown.
