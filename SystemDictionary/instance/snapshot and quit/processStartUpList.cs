processStartUpList
	"Call the startUp method on each object that needs to gracefully restart itself after a snapshot."

	DisplayScreen startUp.
	Cursor startUp.
	Smalltalk installLowSpaceWatcher.
	InputSensor startUp.
	ProcessorScheduler startUp.
	Delay startUp.
	Smalltalk startUp.
	ControlManager startUp.
