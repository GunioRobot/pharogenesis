paragraph
	"Answer the paragraph."

	|p|
	p := super paragraph.
	self selectionColor: self selectionColor.
	^p