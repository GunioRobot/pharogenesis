spawnNewProcess
	exitFlag _ false.
	activeProcess _
		[[World doOneCycle.  Processor yield.  exitFlag] whileFalse: [].
		self exit]
			newProcess priority: Processor userSchedulingPriority.
	activeProcess resume.
	Processor terminateActive