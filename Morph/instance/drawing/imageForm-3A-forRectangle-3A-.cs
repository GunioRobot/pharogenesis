imageForm: depth forRectangle: rect
	| canvas |
	canvas _ Display defaultCanvasClass extent: rect extent depth: depth.
	canvas translateBy: rect topLeft negated
		during:[:tempCanvas| tempCanvas fullDrawMorph: self].
	^ canvas form offset: rect topLeft