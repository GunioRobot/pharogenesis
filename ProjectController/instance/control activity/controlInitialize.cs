controlInitialize  "Overridden to allow single-click entry"
	view displayEmphasized.
	view uncacheBits.  "Release cached bitmap while active"
	self labelHasCursor ifTrue: [sensor waitNoButton].
	status _ #active