getEvaluationContext
	"Return a context containing the namespace for evaluating a statement "

	^ (myWorkspace dependents last select model: myWorkspace).
