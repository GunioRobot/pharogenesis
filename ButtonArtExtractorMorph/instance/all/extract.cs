extract

	| selRect thisF holder uniqueForms |
	selRect _ selectionRect innerBounds translateBy: visibleLayer topLeft negated.
	uniqueForms _ OrderedCollection new.
	layers do: [:f |
		thisF _ f copy: selRect.
		uniqueForms detect: [:oldF | oldF bits = thisF bits] ifNone: [uniqueForms add: thisF]].
	holder _ HolderMorph new.
	uniqueForms do: [:f | holder addMorphBack: (SketchMorph new form: f)].
	self world addMorph: holder.
