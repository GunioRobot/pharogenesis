hasVertexColors
	1 to: self size do:[:i|
		(self at: i) hasVertexColors ifFalse:[^false]].
	^true