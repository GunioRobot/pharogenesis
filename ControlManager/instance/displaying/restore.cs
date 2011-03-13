restore 
	"Clear the screen to gray and then redisplay all the scheduled views.  Try to be a bit intelligent about the view that wants control and not display it twice if possible."

	scheduledControllers first view uncacheBits.  "assure refresh"
	self unschedule: screenController; scheduleOnBottom: screenController.
	screenController view window: Display boundingBox; displayDeEmphasized.
	self scheduledWindowControllers reverseDo:
		[:aController | aController view displayDeEmphasized].
