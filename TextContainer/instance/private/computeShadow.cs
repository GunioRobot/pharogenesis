computeShadow
	| canvas back bounds theText |
	bounds _ self bounds.
	theText _ textMorph meOrMyDropShadow.
	canvas _ (Display defaultCanvasClass extent: bounds extent depth: 1)
			shadowColor: Color black.
	canvas translateBy: bounds topLeft negated during:[:tempCanvas|
		self fillsOwner
			ifTrue: [(theText owner copyWithoutSubmorph: theText) fullDrawOn: tempCanvas]
			ifFalse: [tempCanvas fillRectangle: textMorph bounds color: Color black].
		self avoidsOcclusions ifTrue:
			[back _ tempCanvas form deepCopy.
			tempCanvas form fillWhite.
			theText owner submorphsInFrontOf: theText do:
				[:m | (textMorph isLinkedTo: m)
					ifTrue: []
					ifFalse: [m fullDrawOn: tempCanvas]].
			back displayOn: tempCanvas form at: 0@0 rule: Form reverse].
	].
	shadowForm _ canvas form offset: bounds topLeft.
	vertProfile _ shadowForm  yTallyPixelValue: 1 orNot: false.
	rectangleCache _ Dictionary new.
	^ shadowForm