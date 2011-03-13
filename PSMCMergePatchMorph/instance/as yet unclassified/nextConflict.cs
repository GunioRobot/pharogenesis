nextConflict
	"Answer the first conflict or, if the current selection is a conflict,
	the subsequent conflict."

	|coll current index|
	current := self selectedChangeWrapper.
	coll := current isConflict
		ifTrue: [(self model
					copyFrom: (index := self model indexOf: current item) + 1
					to: self model size),
				(self model copyFrom: 1 to: index)]
		ifFalse: [self model].
	^coll detect: [:item | item isConflict] ifNone: [nil]