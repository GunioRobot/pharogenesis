mouseEnter: evt
	"Resume drop-tracking in enclosing editor"
	| ed |
	(ed _ self enclosingEditor) ifNotNil:
		[ed mouseLeave: evt]