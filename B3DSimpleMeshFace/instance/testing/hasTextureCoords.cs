hasTextureCoords
	1 to: self size do:[:i|
		(self at: i) hasTextureCoords ifFalse:[^false]].
	^true