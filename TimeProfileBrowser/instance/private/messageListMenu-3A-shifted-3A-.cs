messageListMenu: aMenu shifted: shifted
	"Add a menu to the inherited one."

	| menu |
	menu := super messageListMenu: aMenu shifted: shifted.
"	menu addItem: (0)."
	^menu