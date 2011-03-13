processStartUpList
	"Call the startUp method on each object that needs to gracefully restart itself after a snapshot."

	DisplayScreen startUp.
	Cursor startUp.
	InputSensor startUp.
	ProcessorScheduler hiddenBackgroundProcess.
	Delay startUp.
	Smalltalk startUp.
	ControlManager startUp.  "NOTE: The active process terminates here."
