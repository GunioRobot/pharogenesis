instrumentChoicesForTrack: trackIndex
	| names |
	names _ AbstractSound soundNames asOrderedCollection.
	names add: 'clink'.
	names add: 'edit ' , (trackInstNames at: trackIndex).
	^ names asArray
