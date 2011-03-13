nameAndRulesFor: aProcess 
	"Answer a nickname and two flags: allow-stop, and allow-debug"
	(aProcess priority = Processor timingPriority
			and: [aProcess suspendedContext receiver == Delay])
		ifTrue: [^ {'the timer interrupt watcher'. false. false}].
	^ aProcess caseOf: {
		[] -> [{'no process'. false. false}].
		[autoUpdateProcess] -> [{'my auto-update process'. true. true}].
		[Smalltalk lowSpaceWatcherProcess] -> [{'the low space watcher'. false. false}].
		[WeakArray runningFinalizationProcess] -> [{'the WeakArray finalization process'. false. false}].
		[Processor activeProcess] -> [{'the UI process'. false. true}].
		[Processor backgroundProcess] -> [{'the idle process'. false. false}].
		[Sensor inputProcess] -> [{'the I/O process'. false. false}].
		[Sensor interruptWatcherProcess] -> [{'the user interrupt watcher'. false. false}].
		[Project uiProcess] -> [{'the inactive Morphic UI process'. false. false}].
		[ScheduledControllers activeControllerProcess] -> [{'the inactive MVC controller process'. false. true}]}
		 otherwise: [{aProcess suspendedContext asString. true. true}]