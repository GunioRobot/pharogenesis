closeAllDebuggers
	"Utilities closeAllDebuggers"
	(SystemWindow allSubInstances select: [:w | w model isKindOf: Debugger])
			do: [:w | w delete]