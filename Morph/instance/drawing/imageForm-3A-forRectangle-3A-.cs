imageForm: depth forRectangle: rect
	| canvas |
	canvas _ Display defaultCanvasClass extent: rect extent depth: depth.
	canvas translateBy: rect topLeft negated
		during:[:tempCanvas| self fullDrawOn: tempCanvas].
	^ canvas form offset: rect topLeft