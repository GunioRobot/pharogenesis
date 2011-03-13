Object
	subclass: #Delay
	instanceVariableNames: 'delayDuration resumptionTime delaySemaphore beingWaitedOn '
	classVariableNames: 'ActiveDelayStartTime SuspendedDelays ActiveDelay AccessProtect TimingSemaphore '
	poolDictionaries: ''
	category: 'Kernel-Processes'