raiseContextMenu: characterStream 
	(morph respondsTo: #editView)
		ifTrue: [morph editView yellowButtonActivity: ActiveEvent shiftPressed]
		ifFalse: [sensor keyboard.
			"consume the character"
			morph yellowButtonActivity: false].
	^ true