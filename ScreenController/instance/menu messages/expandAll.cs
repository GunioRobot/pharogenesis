expandAll
	"Reopens all collapsed windows"
	ScheduledControllers scheduledControllers reverseDo:
		[:controller | controller == self ifFalse:
			[controller view isCollapsed
				ifTrue:  [controller view expand]
				ifFalse: [controller view displayDeEmphasized]]]