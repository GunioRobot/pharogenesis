undergoMarch99Conversion
	"A one-time conversion to be applied to old instances of TabbedPalette that still have TabMorphs in them instead of the newer ReferenceMorphs.  Return an integer telling how many tabs were changed"

	"TabbedPalette allInstancesDo: [:m | m undergoMarch99Conversion]"

	| count |
	tabsMorph ifNil: [^ 0].
	count _ 0.
	tabsMorph submorphs do:
		[:m | (m isKindOf: TabMorph)
			ifTrue:
				[m convertToReferenceMorph.
				count _ count + 1]].
	^ count