collapseAll
	"Collapses all open windows"
	ScheduledControllers scheduledControllers do:
		[:controller | controller == self ifFalse:
			[controller view isCollapsed ifFalse:
					[controller collapse.
					controller view deEmphasize]]]