standardSystemController
	^ScheduledControllers controllerSatisfying: 
			[:c | 
			c view subViews notEmpty and: [c view firstSubView model == self]]