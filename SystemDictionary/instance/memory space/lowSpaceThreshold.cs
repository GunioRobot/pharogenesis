lowSpaceThreshold
	"Return the low space threshold. When the amount of free memory (after garbage collection) falls below this limit, the system is in serious danger of completely exhausting memory and crashing. This limit should be made high enough to allow the user open a debugger to diagnose a problem or to save the image."

	thisContext isPseudoContext
		ifTrue: [^ 300000  "Allow for translated methods"]
		ifFalse: [^ 100000  "Enough for interpreter"]