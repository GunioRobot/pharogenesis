controlInitialize
	view displayEmphasized.
	view uncacheBits.  "Release cached bitmap while active"
	sensor waitNoButton.
	status _ #active.
	view topView isCollapsed ifFalse: [model modelWakeUp].