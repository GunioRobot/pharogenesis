operateOnSubmorph: aMorph event: evt
	"Invoke the morph menu for the given submorph."

	| menu |
	menu _ self buildMorphMenuFor: aMorph.
	menu addTitle: aMorph class name.
	self invokeMenu: menu event: evt.
