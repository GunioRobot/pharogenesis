unzipped
	| magic1 magic2 |
	magic1 _ (self at: 1) asInteger.
	magic2 _ (self at: 2) asInteger.
	(magic1 = 16r1F and:[magic2 = 16r8B]) ifFalse:[^self].
	^(GZipReadStream on: self) upToEnd