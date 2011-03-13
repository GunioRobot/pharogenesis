initialize
	"Initialize a new ParagraphEditor.  It is initially not in control, so its
	 would-be-instance variables, UndoInterval and PriorInterval, are stashed in
	 beginTypeInBlock."

	super initialize.
	self initializeYellowButtonMenu.
	beginTypeInBlock _ Array with: (1 to: 0) with: (1 to: 0)