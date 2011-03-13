from: aPopupMenu title: titleStringOrNil
	"Answer a MenuMorph constructed from the given PopUpMenu. Used to simulate MVC-style menus in a Morphic-only world."

	| menu items lines selections |
	menu _ self new.
	titleStringOrNil ifNotNil: [
		titleStringOrNil isEmpty ifFalse: [menu addTitle: titleStringOrNil]].
	items _ aPopupMenu labelString asString findTokens: String cr.
	lines _ aPopupMenu lineArray.
	lines ifNil: [lines _ #()].
	menu cancelValue: 0.
	selections _ (1 to: items size) asArray.
	1 to: items size do: [:i |
		menu add: (items at: i) action: (selections at: i).
		(lines includes: i) ifTrue: [menu addLine]].
	^ menu
