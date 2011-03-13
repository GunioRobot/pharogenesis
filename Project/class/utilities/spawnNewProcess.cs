spawnNewProcess

	UIProcess _ [
		[World doOneCycle.  Processor yield.  false] whileFalse: [].
	] newProcess priority: Processor userSchedulingPriority.
	UIProcess resume