processStartUpList
	"Call the startUp method on each object that needs to gracefully restart itself after a snapshot."

	DisplayScreen startUp.
	FileDirectory startUp.
	Cursor startUp.
	Smalltalk installLowSpaceWatcher.
	InputSensor startUp.
	ProcessorScheduler startUp.
	Delay startUp.
	Smalltalk startUp.
	Smalltalk isMorphic
		ifTrue: [World fullRepaintNeeded]
		ifFalse: [ControlManager startUp].
