testRemoveIfAbsent
	| result1 result2  |
	result1 := true.
	result2 := true.
	full remove: 8 ifAbsent: [ result1 := false ].
	self assert: (result1 = false).
	full remove: 5 ifAbsent: [ result2 := false ].
	self assert: (result2 = true).
	
	
	