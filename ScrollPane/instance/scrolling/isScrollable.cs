isScrollable
	(Preferences valueOfFlag: #hiddenScrollBars) ifFalse: [^ true].

	"If the contents of the pane are too small to scroll, return false."
	^ self unadjustedScrollRange > 0
		"treat a single line as non-scrollable"
		and: [self totalScrollRange > (self scrollDeltaHeight * 3/2)]