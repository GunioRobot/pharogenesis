browseClassRefs

	classListIndex=0 ifTrue: [^ self].
	Smalltalk browseAllCallsOn: (Smalltalk associationAt: self selectedClass name)
