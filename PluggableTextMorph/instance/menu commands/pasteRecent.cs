pasteRecent
	"Paste an item chosen from RecentClippings."

	| clipping |
	(clipping _ ParagraphEditor chooseRecentClipping) ifNil: [^ self].
	ParagraphEditor clipboardTextPut: clipping.
	^ self handleEdit: [textMorph editor paste]