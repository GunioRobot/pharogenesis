removeEmptyLayoutMorphs
	submorphs copy do: [:m |
		m isLayoutMorph
			ifTrue:
				[m submorphCount = 0
					ifTrue:
						[m delete]
					ifFalse:
						[m removeEmptyLayoutMorphs]]].
	self fullBounds.
	self layoutChanged