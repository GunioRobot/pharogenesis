isScrollbarShowing
	"Return true if a retractable scroll bar is currently showing"
	retractableScrollBar ifFalse:[^true].
	^submorphs includes: scrollBar