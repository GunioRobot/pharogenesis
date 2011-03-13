addButton: buttonFlag
"we need a button on the window. If there is already one, ignore this. 
If the host window does not yet exist we need only set the flag. If there is
already a window, we will need to destroy the old window, add the flag and recreate"

	"do we already have a button? - if so just return"
	(self hasButton: buttonFlag) ifTrue:[^self].

	"add the close button flag"
	self addFlag: buttonFlag.
	"note that we have a titlebar in order for the button to exist"
	self addFlag: HasTitleBar.

	"if we have a window recreate it"
	self isOpen ifTrue:[self recreate]