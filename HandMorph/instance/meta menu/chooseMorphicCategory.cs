chooseMorphicCategory
	"Put up a menu listing all the Morphic categories, and return the one chosen, or nil if none"

	| menu prefix categories |
	menu _ CustomMenu new.
	prefix _ 'Morphic-'.
	categories _ SystemOrganization categories select:
		[:c | (c beginsWith: prefix) and: [(c endsWith: 'Support') not]].
	categories do: [:c | menu add: (c copyFrom: prefix size + 1 to: c
size) action: c].
	^  menu startUp

	"HandMorph new chooseMorphicCategory"
