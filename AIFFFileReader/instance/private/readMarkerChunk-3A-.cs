readMarkerChunk: chunkSize

	| markerCount id position labelBytes label |
	markerCount _ in nextNumber: 2.
	markers _ Array new: markerCount.
	1 to: markerCount do: [:i |
		id _ in nextNumber: 2.
		position _ in nextNumber: 4.
		labelBytes _ in next.
		label _ (in next: labelBytes) asString.
		labelBytes even ifTrue: [in skip: 1].
		markers at: i put: (Array with: id with: label with: position)].

