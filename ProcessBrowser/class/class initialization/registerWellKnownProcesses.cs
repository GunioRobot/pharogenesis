registerWellKnownProcesses
	"Associate each well-known process with a nickname and two flags: allow-stop, and allow-debug.
	Additional processes may be added to this list as required"

	WellKnownProcesses := OrderedCollection new.
	self registerWellKnownProcess: []
		label: 'no process'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess: [Smalltalk lowSpaceWatcherProcess]
		label: 'the low space watcher'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess: [WeakArray runningFinalizationProcess]
		label: 'the WeakArray finalization process'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess: [Processor activeProcess]
		label: 'the UI process'
		allowStop: false
		allowDebug: true.
	self registerWellKnownProcess: [Processor backgroundProcess]
		label: 'the idle process'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess: [Sensor interruptWatcherProcess]
		label: 'the user interrupt watcher'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess: [Sensor eventTicklerProcess]
		label: 'the event tickler'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess: [Project uiProcess]
		label: 'the inactive Morphic UI process'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess:
			[Smalltalk at: #SoundPlayer ifPresent: [:sp | sp playerProcess]]
		label: 'the Sound Player'
		allowStop: false
		allowDebug: false.
	self registerWellKnownProcess:
			[ScheduledControllers ifNotNil: [ScheduledControllers activeControllerProcess]]
		label: 'the inactive MVC controller process'
		allowStop: false
		allowDebug: true.
	self registerWellKnownProcess:
			[Smalltalk at: #CPUWatcher ifPresent: [:cw | cw currentWatcherProcess]]
		label: 'the CPUWatcher'
		allowStop: false
		allowDebug: false
