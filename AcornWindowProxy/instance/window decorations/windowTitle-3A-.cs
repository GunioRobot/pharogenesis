windowTitle: titleString 
	"set the window title. If the window is open and doesn't already have a
titlebar, add the title bar, recreate and set the title"
	(self isOpen and: [self hasTitleBar not])
		ifTrue:[ 
			"note that we have a titlebar in order for the title to exist"
			self addFlag: HasTitleBar.
			self recreate].
	super windowTitle: titleString