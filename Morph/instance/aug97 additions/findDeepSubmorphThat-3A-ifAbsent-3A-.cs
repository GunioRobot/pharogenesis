findDeepSubmorphThat: block1 ifAbsent: block2
	^ self allMorphs detect: [:m | (block1 value: m) == true] ifNone: [block2 value]
	