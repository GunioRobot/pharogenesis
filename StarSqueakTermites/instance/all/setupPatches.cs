setupPatches
	"Create patch variables for sensing the nest and food caches. The nestScent variable is diffused so that it forms a 'hill' of scent over the entire world with its peak at the center of the nest. That way, the ants always know which way the nest is."

	self createPatchVariable: 'woodChips'.  "number of wood chips on patch"
	self displayPatchVariable: 'woodChips' logScale: 5.
	self patchesDo: [:p |
		(self random: 8) = 0
			ifTrue: [p set: 'woodChips' to: 1]
			ifFalse: [p set: 'woodChips' to: 0]].
