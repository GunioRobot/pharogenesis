createHierarchyFrom3DS: globals
	| keyframes objects hierarchy name parentID parentName parent |
	hierarchy _ Dictionary new.
	keyframes _ globals at: #keyframes ifAbsent:[^hierarchy].
	objects _ keyframes at: #objects ifAbsent:[^hierarchy].
	objects do:[:obj|
		name _ obj at: #name.
		parentID _ obj at: #hierarchy.
		parent _ objects at: parentID ifAbsent:[nil].
		parent == nil ifFalse:[
			parentName _ parent at: #name.
			name = parentName
				ifFalse:[hierarchy at: name put: parentName]].
	].
	^hierarchy