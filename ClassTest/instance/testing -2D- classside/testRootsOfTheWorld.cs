testRootsOfTheWorld
	self assert: Class rootsOfTheWorld size = 3.
	self assert: (Class rootsOfTheWorld allSatisfy: [:each | each superclass = nil]).
	