syllable: aSyllable
	super syllable: aSyllable.

	aSyllable isAccented ifFalse: [^ self].
	aSyllable accent = 'H*' ifTrue: [^ self renderPeakAccent].
	aSyllable accent = 'L*' ifTrue: [^ self renderLowAccent].
	aSyllable accent = 'L*+H' ifTrue: [^ self renderScoopedAccent].
	aSyllable accent = 'L+H*' ifTrue: [^ self renderRisingPeakAccent]