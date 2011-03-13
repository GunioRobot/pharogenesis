mouseOverHalosString
	"Answer the string to be shown in a menu to represent the mouse-over-halos status"

	^ self wantsMouseOverHalos
		ifTrue:
			['<on>mouse-over halos']
		ifFalse:
			['<off>mouse-over halos']
