setupFire

	self patchesDo: [:p |
		p neighborW isLeftEdge ifTrue: [
			p set: #isUnburnt to: 0.
			p set: #flameLevel to: 100.
			p color: Color red]].
