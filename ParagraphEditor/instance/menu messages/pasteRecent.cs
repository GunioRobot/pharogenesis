pasteRecent
	"Paste an item chose from RecentClippings."

	| clipping |
	(clipping _ self class chooseRecentClipping) ifNil: [^ self].
	CurrentSelection _ clipping.
	^ self paste