installEventSensorFramework: fetcherClass
	"Installs the new sensor framework."
	"InputEventSensor installEventSensorFramework: InputEventPollingFetcher"

	| newSensor |
	"Do some extra cleanup"
	{InputEventFetcher. InputEventPollingFetcher. InputSensor. }
		do: [:oldSensorClass |
			Smalltalk removeFromShutDownList: oldSensorClass.
			Smalltalk removeFromStartUpList: oldSensorClass].

	InputEventFetcher deinstall.

	newSensor := self new.
	fetcherClass install.
	newSensor registerIn: InputEventPollingFetcher default.
	
	"Shut down old sensor"
	Sensor shutDown.
	Smalltalk removeFromShutDownList: Sensor class.
	Smalltalk removeFromStartUpList: Sensor class.

	(Preferences allPreferenceObjects select: [:pref | pref changeInformee = InputSensor])
		do: [:pref | pref changeInformee: newSensor class].
	(Preferences allPreferenceObjects select: [:pref | pref changeInformee = Sensor class])
		do: [:pref | pref changeInformee: newSensor class].


	"Note: We must use #become: here to replace all references to the old sensor with the new one, since Sensor is referenced from all the existing controllers."
	Sensor becomeForward: newSensor. "done"

	"Register the interrupt handler"
	UserInterruptHandler new registerIn: InputEventFetcher default.

	Smalltalk addToStartUpList: Sensor class after: fetcherClass.
	Smalltalk addToShutDownList: Sensor class after: Form.

	"Project spawnNewProcessAndTerminateOld: true"