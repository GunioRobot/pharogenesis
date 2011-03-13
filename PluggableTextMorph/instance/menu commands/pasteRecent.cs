pasteRecent
	"Paste an item chosen from RecentClippings."

	| clipping |
	(clipping _ Clipboard chooseRecentClipping) ifNil: [^ self].
	Clipboard clipboardText: clipping.
	^ self handleEdit: [textMorph editor paste]