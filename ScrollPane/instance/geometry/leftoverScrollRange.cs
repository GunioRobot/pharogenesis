leftoverScrollRange
	"Return the entire scrolling range minus the currently viewed area."
	^ self totalScrollRange - (bounds height * 3 // 4) max: 0
