initialize

	super initialize.
	color _ self normalColor.
	self addLabel: 'Trash'.
	submorphs first lock. "So the string won't get the halo on its own"
	self setBalloonText:
'The Trash Can
To remove an object, drag it
over the Trash, and drop it,
and it will disappear.'.
	self on: #mouseUp send: #openTrash to: self.
	self on: #mouseEnter send: #showCursor: to: self.
	self on: #mouseLeave send: #hideCursor: to: self.