findOrMakeMethodChangeAt: selector priorMethod: priorMethod

	^ methodChanges at: selector
		ifAbsent: [methodChanges at: selector
						put: (MethodChangeRecord new priorMethod: priorMethod)]