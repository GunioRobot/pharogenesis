computeShadow
	| canvas back bounds |
	bounds _ self bounds.
	canvas _ (FormCanvas extent: bounds extent depth: 1)
			setShadowDrawing; stipple: Color black;
			copyOffset: bounds topLeft negated.
	self fillsOwner
		ifTrue: [(textMorph owner copyWithoutSubmorph: textMorph) fullDrawOn: canvas]
		ifFalse: [canvas fillRectangle: textMorph bounds color: Color black].
	self avoidsOcclusions ifTrue:
		[back _ canvas form deepCopy.
		canvas form fillWhite.
		textMorph owner submorphsInFrontOf: textMorph do:
			[:m | (textMorph isLinkedTo: m)
				ifTrue: []
				ifFalse: [m fullDrawOn: canvas]].
		back displayOn: canvas form at: 0@0 rule: Form reverse].
	shadowForm _ canvas form offset: bounds topLeft.
	vertProfile _ shadowForm  yTallyPixelValue: 1 orNot: false.
	rectangleCache _ Dictionary new.
	^ shadowForm