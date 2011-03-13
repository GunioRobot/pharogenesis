views
	| sc |
	sc _ projectWindows screenController.
	^ projectWindows scheduledControllers 
		select: [:c | c ~~ sc]
		thenCollect: [:c | c view]