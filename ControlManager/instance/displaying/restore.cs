restore
	"Clear the screen to gray and then redisplay all the scheduled views.  Try to be a bit intelligent about the view that wants control and not display it twice if possible..
	1/24/96 sw: uncache bits of top view"

	scheduledControllers first view uncacheBits.  "assure refresh"
	self unschedule: screenController; scheduleOnBottom: screenController.
	screenController view window: Display boundingBox.
	scheduledControllers reverseDo:
		[:aController | aController view displayDeEmphasized].
