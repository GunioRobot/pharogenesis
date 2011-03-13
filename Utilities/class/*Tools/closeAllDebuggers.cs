closeAllDebuggers
	"Utilities closeAllDebuggers"
	Smalltalk isMorphic
	ifTrue:
		[(SystemWindow allSubInstances select: [:w | w model isKindOf: Debugger])
			do: [:w | w delete]]
	ifFalse:
		[(StandardSystemController allInstances select: [:w | w model isKindOf: Debugger])
			do: [:w | w closeAndUnscheduleNoTerminate]]