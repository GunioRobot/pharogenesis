findSubmorphThat: block1 ifAbsent: block2
	^ submorphs detect: [:m | (block1 value: m) == true] ifNone: [block2 value]
	