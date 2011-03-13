pasteRecent
	"Paste an item chose from RecentClippings."

	| clipping |
	(clipping _ Clipboard chooseRecentClipping) ifNil: [^ self].
	Clipboard clipboardText: clipping.
	^ self paste