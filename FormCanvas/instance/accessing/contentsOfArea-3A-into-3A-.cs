contentsOfArea: aRectangle into: aForm
	self flush.
	port contentsOfArea: ((aRectangle origin + origin) negated extent: aRectangle extent)
		into: aForm.
	^aForm