shuffled
	| copy random max |  "($A to: $Z) shuffled"
	copy _ self shallowCopy.
	random _ Random new.
	max _ self size.
	1 to: max do: [:i | copy swap: i with: (random next * max) asInteger + 1].
	^ copy