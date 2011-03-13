fullScreen
	| aController aWorld |
	aWorld _ self world.
	aController _ ScheduledControllers scheduledWindowControllers detect: [:c | (c view subViews size > 0) and: [c view subViews first model == aWorld]].
	aController fullScreen