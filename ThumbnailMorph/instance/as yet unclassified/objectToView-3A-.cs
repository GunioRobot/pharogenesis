objectToView: objectOrNil
	(objectOrNil isMorph and: [objectOrNil allMorphs includes: self]) ifTrue:
		["cannot view a morph containing myself or drawOn: goes into infinite recursion"
		objectToView _ nil.
		^ self].
	objectToView _ objectOrNil