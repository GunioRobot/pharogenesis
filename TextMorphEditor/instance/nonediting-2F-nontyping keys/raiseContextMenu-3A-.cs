raiseContextMenu: characterStream 
	(morph respondsTo: #editView)
		ifTrue: [morph editView yellowButtonActivity: ActiveEvent shiftPressed].
	^ true