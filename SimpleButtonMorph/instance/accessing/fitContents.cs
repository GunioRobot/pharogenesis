fitContents
	| aMorph aCenter |
	aCenter _ self center.
	submorphs size = 0 ifTrue: [^ self].
	aMorph _ submorphs first.
	self extent: aMorph extent + (borderWidth + 6).
	self center: aCenter.
	aMorph position: aCenter - (aMorph extent // 2)
