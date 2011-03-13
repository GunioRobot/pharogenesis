mouseDown: evt
	"Changed to only take focus if wanted."
	
	| selectors row |
	evt yellowButtonPressed  "First check for option (menu) click"
		ifTrue: [^ self yellowButtonActivity: evt shiftPressed].
	self enabled ifFalse: [^self].
	self wantsKeyboardFocus
		ifTrue: [self takeKeyboardFocus].
	row := self rowAtLocation: evt position.
	row = 0  ifTrue: [^super mouseDown: evt].
	self mouseDownRow: row.
	selectors := Array 
		with: #click:
		with: (doubleClickSelector ifNotNil:[#doubleClick:])
		with: nil
		with: (self dragEnabled ifTrue:[#startDrag:] ifFalse:[nil]).
	evt hand waitForClicksOrDrag: self event: evt selectors: selectors threshold: 10 "pixels".