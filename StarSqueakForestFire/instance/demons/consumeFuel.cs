consumeFuel

	| level |
	self patchesDo: [:p |
		level _ p get: #flameLevel.
		level > 0 ifTrue: [
			level _ (level - 15) max: 0.
			p set: #flameLevel to: level.
			p brightness: level]].
