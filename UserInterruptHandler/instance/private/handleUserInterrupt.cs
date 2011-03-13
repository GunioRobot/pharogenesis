handleUserInterrupt
"	[Project interruptName: 'User Interrupt' preemptedProcess: Project uiProcess] fork"
	[Project uiProcess debugWithTitle: 'User Interrupt'] fork