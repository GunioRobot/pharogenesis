mouseLeave: evt
	"Resume drop-tracking in enclosing editor"
	| ed |
	(ed _ self enclosingEditor) ifNotNil:
		[ed mouseEnter: evt]