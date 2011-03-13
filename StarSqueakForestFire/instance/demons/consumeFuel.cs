consumeFuel

	| level |
	self patchesDo: [:p |
		level := p get: #flameLevel.
		level > 0 ifTrue: [
			level := (level - 15) max: 0.
			p set: #flameLevel to: level.
			p brightness: level]].
