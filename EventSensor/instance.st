InputSensor
	subclass: #EventSensor
	instanceVariableNames:
		'mouseButtons mousePosition keyboardBuffer interruptKey interruptSemaphore eventQueue inputProcess inputSemaphore '
	classVariableNames: 'EventPollFrequency '
	poolDictionaries: 'EventSensorConstants '
	category: 'Kernel-Processes'