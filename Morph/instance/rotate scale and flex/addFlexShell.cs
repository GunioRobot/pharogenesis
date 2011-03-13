addFlexShell
	"Wrap a rotating and scaling shell around this morph."

	| oldHalo flexMorph myWorld anIndex |

	myWorld _ self world.
	oldHalo _ self halo.
	anIndex _ self owner submorphIndexOf: self.
	self owner addMorph: (flexMorph _ self newTransformationMorph asFlexOf: self)
		asElementNumber: anIndex.
	self transferStateToRenderer: flexMorph.
	oldHalo ifNotNil: [oldHalo setTarget: flexMorph].
	myWorld ifNotNil: [myWorld startSteppingSubmorphsOf: flexMorph].

	^ flexMorph