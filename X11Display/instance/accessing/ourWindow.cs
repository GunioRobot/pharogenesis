ourWindow
	"Guess the window to draw on."
	| window ptr child |
	window _ self getInputFocus.
	ptr _ self queryPointer: window.	 "{root. child. root pos. win pos. mask}"
	child _ ptr second.
	child xid = 0 ifTrue: [^ window].
	^ child