flushLog
	(log == Transcript) ifTrue:[
		log endEntry.
		Sensor leftShiftDown ifTrue:[self halt].
	].