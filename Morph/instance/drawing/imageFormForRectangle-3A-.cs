imageFormForRectangle: rect
	| canvas |
	canvas _ FormCanvas extent: rect extent.
	self fullDrawOn: (canvas copyOffset: rect topLeft negated).
	^ canvas form offset: rect topLeft