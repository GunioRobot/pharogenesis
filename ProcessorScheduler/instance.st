Object
	subclass: #ProcessorScheduler
	instanceVariableNames: 'quiescentProcessLists activeProcess '
	classVariableNames:
		'UserBackgroundPriority UserSchedulingPriority TimingPriority SystemBackgroundPriority BackgroundProcess SystemRockBottomPriority HighIOPriority LowIOPriority UserInterruptPriority '
	poolDictionaries: ''
	category: 'Kernel-Processes'