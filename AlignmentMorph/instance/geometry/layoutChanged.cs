layoutChanged

	layoutNeeded ifTrue: [^ self].  "In process."
	layoutNeeded _ true.
	priorFullBounds _ fullBounds.  "Remember fullBounds"
	super layoutChanged.
