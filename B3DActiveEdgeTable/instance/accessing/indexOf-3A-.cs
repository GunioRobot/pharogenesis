indexOf: anEdge
	1 to: stop do:[:i| (array at: i) = anEdge ifTrue:[^i]].
	^0