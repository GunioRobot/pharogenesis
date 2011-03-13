initializeLabelArea
	super initializeLabelArea.
	collapseBox hide.  " need to keep collapseBox for title bar to display correctly?"
	expandBox delete.
	menuBox delete.
	expandBox := nil.
	collapseBox := nil.