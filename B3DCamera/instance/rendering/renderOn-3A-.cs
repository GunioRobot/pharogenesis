renderOn: aRenderer
	aRenderer
		lookFrom: self position
		to: self target
		up: self up.
	aRenderer
		perspective: self perspective.