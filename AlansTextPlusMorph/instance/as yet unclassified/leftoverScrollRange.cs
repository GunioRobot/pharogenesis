leftoverScrollRange
	"Return the entire scrolling range minus the currently viewed area."
	^ self totalScrollRange - bounds height max: 0
