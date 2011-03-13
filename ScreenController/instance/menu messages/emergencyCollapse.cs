emergencyCollapse
	"Emergency collapse of a selected window"
	| controller |
	(controller := ScheduledControllers windowFromUser) notNil
		ifTrue:
			[controller collapse.
			controller view deEmphasize]