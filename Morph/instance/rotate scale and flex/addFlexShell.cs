addFlexShell
	"Wrap a rotating and scaling shell around this morph."

	| oldHalo flexMorph |
	oldHalo _ self halo.
	self owner addMorph:
		(flexMorph _ self newTransformationMorph asFlexOf: self).
	self transferStateToRenderer: flexMorph.
	oldHalo ifNotNil: [oldHalo setTarget: flexMorph].
	self currentWorld startSteppingSubmorphsOf: flexMorph.

	^ flexMorph