offerMenuFromEsc: characterStream 
	"The escape key was hit while the receiver has the keyboard focus; take action"

	^ ActiveEvent shiftPressed 
		ifTrue:
			[self escapeToDesktop: characterStream]
		ifFalse:
			[self raiseContextMenu: characterStream]