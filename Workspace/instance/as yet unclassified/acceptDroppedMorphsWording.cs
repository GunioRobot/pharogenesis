acceptDroppedMorphsWording

	^ self acceptsDroppingMorphForReference
		ifTrue: ['<yes> create textual references to dropped morphs']
		ifFalse: ['<no> create textual references to dropped morphs']
