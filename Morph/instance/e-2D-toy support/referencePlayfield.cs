referencePlayfield
	"Answer the PasteUpMorph to be used for cartesian-coordinate reference"

	| former |
	owner ifNotNil:
		[owner isPlayfieldLike ifTrue: [^ owner].
		(owner isHandMorph and: [(former _ self formerOwner) notNil])
			ifTrue:
				[^ former isPlayfieldLike 
					ifTrue: [former]
					ifFalse: [former referencePlayfield]]].
	^ self world