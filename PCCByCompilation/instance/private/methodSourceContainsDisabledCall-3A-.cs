methodSourceContainsDisabledCall: methodSource 
	^ (methodSource findString: self disabledPrimStartString)
		~= 0