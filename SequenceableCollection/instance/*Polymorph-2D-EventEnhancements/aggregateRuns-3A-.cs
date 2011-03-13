aggregateRuns: aBlock
	"Answer a new collection of the same species as the
	receiver with elements being collections (of the receiver
	species) containing those elements of the receiver
	for which the given block consecutively evaluates to
	the same object."

	|str r eStr t|
	str := Array new writeStream.
	r := nil.
	eStr := Array new writeStream.
	self do: [:e |
		(t := aBlock value: e) = r
			ifTrue: [eStr nextPut: e]
			ifFalse: [r := t.
					eStr isEmpty
						ifFalse: [str nextPut: (eStr contents as: self species).
								eStr reset].
					eStr nextPut: e]].
	eStr isEmpty ifFalse: [str nextPut: (eStr contents as: self species)].
	^str contents as: self species
	