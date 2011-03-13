InputSensor
	subclass: #EventSensor
	instanceVariableNames:
		'mouseButtons mousePosition keyboardBuffer interruptKey interruptSemaphore eventQueue inputSemaphore lastEventPoll hasInputSemaphore'
	classVariableNames: 'EventPollPeriod EventTicklerProcess'
	poolDictionaries: 'EventSensorConstants'
	category: 'Kernel-Processes'