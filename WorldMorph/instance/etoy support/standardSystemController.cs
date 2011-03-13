standardSystemController
	^ ScheduledControllers controllerSatisfying:
		[:c | (c view subViews size > 0) and:
			[c view firstSubView model == self]].
