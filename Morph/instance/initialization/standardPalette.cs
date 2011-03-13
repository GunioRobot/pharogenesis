standardPalette
	"Answer a standard palette forced by some level of enclosing presenter, or nil if none"
	| pal aPresenter itsOwner |
	^ (pal _ (aPresenter _ self presenter) ownStandardPalette)
		ifNotNil: [pal]
		ifNil:	[(itsOwner _ aPresenter associatedMorph owner)
					ifNotNil:
						[itsOwner standardPalette]
					ifNil:
						[nil]]