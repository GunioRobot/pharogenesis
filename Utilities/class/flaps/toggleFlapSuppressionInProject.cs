toggleFlapSuppressionInProject
	Preferences useGlobalFlaps ifFalse:
		[^ self inform: 
'CAUTION!  Global flaps are currently 
disabled, and must be reenabled for 
this option to be meaningful.'].

	Project current flapsSuppressed: Project current flapsSuppressed not.
	self currentWorld restoreDisplay