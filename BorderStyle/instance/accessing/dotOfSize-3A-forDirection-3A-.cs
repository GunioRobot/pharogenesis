dotOfSize: diameter forDirection: aDirection
	| form |
	form _ Form extent: diameter@diameter depth: Display depth.
	form getCanvas fillOval: form boundingBox color: self color.
	^form