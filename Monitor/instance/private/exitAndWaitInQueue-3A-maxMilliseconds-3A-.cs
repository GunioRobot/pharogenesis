exitAndWaitInQueue: anOrderedCollection maxMilliseconds: anIntegerOrNil
	| lock delay |
	queuesMutex 
		critical: [lock _ anOrderedCollection addLast: Semaphore new].
	self exit.
	anIntegerOrNil isNil ifTrue: [
		lock wait
	] ifFalse: [
		delay _ MonitorDelay signalLock: lock afterMSecs: anIntegerOrNil inMonitor: self queue: anOrderedCollection.
		lock wait.
		delay unschedule.
	].
	self enter.