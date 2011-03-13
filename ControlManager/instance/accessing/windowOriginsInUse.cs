windowOriginsInUse
	"Answer a collection of the origins of windows currently on the screen in the current project.  5/21/96 sw"

	^ self scheduledWindowControllers collect: [:aController | aController view displayBox origin].