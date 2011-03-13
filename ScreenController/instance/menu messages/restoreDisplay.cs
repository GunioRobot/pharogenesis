restoreDisplay 
	"Clear the screen to gray and then redisplay all the scheduled views."

	Display extent = DisplayScreen actualScreenSize ifFalse:
		[DisplayScreen startUp.
		ScheduledControllers unCacheWindows].
	ScheduledControllers restore