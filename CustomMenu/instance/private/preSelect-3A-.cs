preSelect: action
	"Pre-select and highlight the menu item associated with the given action."

	| i |
	i _ selections indexOf: action ifAbsent: [^ self].
	marker _ marker
		align: marker topLeft
		with: (marker left)@(frame inside top + (marker height * (i - 1))).
	selection _ i.