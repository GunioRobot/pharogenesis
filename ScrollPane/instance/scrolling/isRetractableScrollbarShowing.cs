isRetractableScrollbarShowing
	"Return true if a retractable scroll bar is currently showing"
	retractableScrollBar ifFalse:[^false].
	^submorphs includes: scrollBar