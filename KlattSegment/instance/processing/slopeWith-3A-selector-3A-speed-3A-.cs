slopeWith: aKlattSegment selector: selector speed: speed
	| me other |
	me _ self parameters at: selector.
	other _ aKlattSegment parameters at: selector.
	^ (self dominates: aKlattSegment)
		ifTrue: [me slopeWithDominated: other speed: speed]
		ifFalse: [me slopeWithDominant: other speed: speed]