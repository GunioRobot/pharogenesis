selectionAndEmphasisPairs: interleavedList
	"An alternative form of call.  "
	| selList  emphList |
	selList _ OrderedCollection new.
	emphList _ OrderedCollection new.
	interleavedList pairsDo:
		[:aSel :anEmph |
			selList add: aSel.
			emphList add: anEmph].
	^ self selections:selList emphases: emphList