addGlasses
	| glass glass2 diameter |
	diameter _ self face leftEye height * 2 // 3.
	glass _ EllipseMorph new extent: diameter @ diameter; color: (Color yellow alpha: 0.5).
	glass2 _ glass copy.
	glass align: glass center with: self face leftEye center.
	glass2 align: glass2 center with: self face rightEye center.
	self addMorph: glass; addMorph: glass2