controlInitialize
	view displayEmphasized.
	view uncacheBits.  "Release cached bitmap while active"
	model windowActiveOnFirstClick ifFalse: [sensor waitNoButton].
	status _ #active.
	view isCollapsed ifFalse: [model modelWakeUpIn: view]