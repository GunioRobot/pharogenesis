removeEmptyLayoutMorphs
	submorphs copy do: [:m |
		m isAlignmentMorph
			ifTrue:
				[m submorphCount = 0
					ifTrue:
						[m delete]
					ifFalse:
						[m removeEmptyLayoutMorphs]]].
	self fullBounds.
	self layoutChanged