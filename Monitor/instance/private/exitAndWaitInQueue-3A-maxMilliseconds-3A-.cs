exitAndWaitInQueue: anOrderedCollection maxMilliseconds: anIntegerOrNil
	| lock delay |
	queuesMutex 
		critical: [lock := anOrderedCollection addLast: Semaphore new].
	self exit.
	anIntegerOrNil isNil ifTrue: [
		lock wait
	] ifFalse: [
		delay := MonitorDelay signalLock: lock afterMSecs: anIntegerOrNil inMonitor: self queue: anOrderedCollection.
		lock wait.
		delay unschedule.
	].
	self enter.