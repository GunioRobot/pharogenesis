standardPalette
	"Answer a standard palette forced by some level of enclosing presenter, or nil if none"
	| pal aPresenter itsOwner |
	(aPresenter _ self presenter) ifNil: [^ nil].
	^ (pal _ aPresenter ownStandardPalette)
		ifNotNil: [pal]
		ifNil:	[(itsOwner _ aPresenter associatedMorph owner)
					ifNotNil:
						[itsOwner standardPalette]
					ifNil:
						[nil]]