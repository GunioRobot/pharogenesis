instrumentChoicesForChannel: channelIndex

	| names inst |
	names _ AbstractSound soundNames asOrderedCollection.
	names _ names collect: [:n |
		inst _ AbstractSound soundNamed: n.
		(inst isKindOf: UnloadedSound)
			ifTrue: [n, '(out)']
			ifFalse: [n]].
	names add: 'clink'.
	names add: 'edit ', (instrumentSelector at: channelIndex) contents.
	^ names asArray
