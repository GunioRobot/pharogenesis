nameAndRulesFor: aProcess 
	"Answer a nickname and two flags: allow-stop, and allow-debug"
	^ [aProcess caseOf: {
		[] -> [{'no process'. false. false}].
		[Smalltalk lowSpaceWatcherProcess] -> [{'the low space watcher'. false. false}].
		[WeakArray runningFinalizationProcess] -> [{'the WeakArray finalization process'. false. false}].
		[Processor activeProcess] -> [{'the UI process'. false. true}].
		[Processor backgroundProcess] -> [{'the idle process'. false. false}].
		[Sensor interruptWatcherProcess] -> [{'the user interrupt watcher'. false. false}].
		[Sensor eventTicklerProcess] -> [{'the event tickler'. false. false}].
		[Project uiProcess] -> [{'the inactive Morphic UI process'. false. false}].
		[Smalltalk
			at: #SoundPlayer
			ifPresent: [:sp | sp playerProcess]] -> [{'the Sound Player'. false. false}].
		[ScheduledControllers
			ifNotNil: [ScheduledControllers activeControllerProcess]] -> [{'the inactive MVC controller process'. false. true}].
		[Smalltalk
			at: #CPUWatcher
			ifPresent: [:cw | cw currentWatcherProcess]] -> [{'the CPUWatcher'. false. false}]}
		 otherwise: 
			[(aProcess priority = Processor timingPriority
					and: [aProcess suspendedContext receiver == Delay])
				ifTrue: [{'the timer interrupt watcher'. false. false}]
				ifFalse: [{aProcess suspendedContext asString. true. true}]]]
		ifError: [:err :rcvr | {aProcess suspendedContext asString. true. true}]