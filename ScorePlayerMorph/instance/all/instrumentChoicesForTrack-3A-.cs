instrumentChoicesForTrack: trackIndex
	| names |
	names _ AbstractSound soundNames asOrderedCollection.
	names add: 'clink'.
	names add: 'edit ' , (instrumentSelector at: trackIndex) contents.
	^ names asArray
