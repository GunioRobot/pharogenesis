asFormOfDepth: d
	| newForm |
	d = self depth ifTrue:[^self].
	newForm _ Form extent: self extent depth: d.
	(BitBlt current toForm: newForm)
		colorMap: (self colormapIfNeededFor: newForm);
		copy: (self boundingBox)
		from: 0@0 in: self
		fillColor: nil rule: Form over.
	^newForm