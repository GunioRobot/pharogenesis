nextPutAll: aCollection

	| newEnd |
	collection class == aCollection class ifFalse:
		[^ super nextPutAll: aCollection ].

	newEnd _ position + aCollection size.
	newEnd > limit ifTrue: [
		super nextPutAll: (aCollection copyFrom: 1 to: (limit - position max: 0)).
		^ limitBlock value.
	].
	newEnd > writeLimit ifTrue: [
		self growTo: newEnd + 10
	].

	collection replaceFrom: position+1 to: newEnd  with: aCollection startingAt: 1.
	position _ newEnd.