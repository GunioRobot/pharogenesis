spreadFire

	self patchesDo: [:p |
		(p get: #isUnburnt) > 0  ifTrue: [
			((p neighborN get: #flameLevel) +
			 (p neighborS get: #flameLevel) +
			 (p neighborE get: #flameLevel) +
			 (p neighborW get: #flameLevel)) > 0 ifTrue: [
				p set: #isUnburnt to: 0.
				p set: #flameLevel to: 100.
				p color: Color red]]].
