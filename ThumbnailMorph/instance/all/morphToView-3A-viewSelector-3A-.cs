morphToView: aMorphOrNil viewSelector: aSelector.

	(aMorphOrNil allMorphs includes: self) ifTrue:
		["cannot view a morph containing myself or drawOn: goes into infinite recursion"
		morphToView _ nil.
		^ self].
	morphToView _ aMorphOrNil..
	viewSelector _ aSelector
