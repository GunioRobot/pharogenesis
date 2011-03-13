toggleFlapSuppressionInProject
	Preferences useGlobalFlaps ifFalse:
		[^ self inform: 
'CAUTION!  Global flaps are currently 
disabled, and must be reenabled for 
this option to be meaningful.'].

	CurrentProjectRefactoring currentToggleFlapsSuppressed.
	Display restoreMorphicDisplay.