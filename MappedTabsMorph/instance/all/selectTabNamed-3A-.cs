selectTabNamed: aString
	self world abandonAllHalos.
	ScheduledControllers scheduledWindowControllers do:
		[:c | ((c view isKindOf: ProjectView)
			and: [c model name = aString])
			 ifTrue: [self highlightTabName: 'unhighlightduetonomatch!'.
					c model enter: false]].
