raiseContextMenu: characterStream 
	(morph respondsTo: #editView)
		ifTrue: [morph editView yellowButtonActivity: ActiveEvent shiftPressed]
		ifFalse: [
			morph yellowButtonActivity: false].
	^ true