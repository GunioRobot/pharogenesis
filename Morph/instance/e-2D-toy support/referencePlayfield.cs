referencePlayfield
	"Answer the PasteUpMorph to be used for cartesian-coordinate reference"

	| former |
	owner ifNotNil:
		[(self topRendererOrSelf owner isHandMorph and: [(former _ self formerOwner) notNil])
			ifTrue:
				[former _ former renderedMorph.
				^ former isPlayfieldLike 
					ifTrue: [former]
					ifFalse: [former referencePlayfield]]].

	self allOwnersDo: [:o | o isPlayfieldLike ifTrue: [^ o]].
	^ ActiveWorld