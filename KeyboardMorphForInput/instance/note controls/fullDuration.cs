fullDuration

	| num denom |
	num _ denom _ 1.
	durationModifier == #dotted ifTrue: [num _ 3.  denom _ 2].
	durationModifier == #triplets ifTrue: [num _ 2.  denom _ 3].
	durationModifier == #quints ifTrue: [num _ 2.  denom _ 5].
	^ pianoRoll score ticksPerQuarterNote * 4 * num // duration // denom