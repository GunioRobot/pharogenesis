Object
	subclass: #Delay
	instanceVariableNames: 'delayDuration resumptionTime delaySemaphore beingWaitedOn '
	classVariableNames: 'AccessProtect ActiveDelay ActiveDelayStartTime SuspendedDelays TimingSemaphore '
	poolDictionaries: ''
	category: 'Kernel-Processes'