updateIfNeeded: aDockingBar 
"Update the given docking bar if needed"
	| timeStamp |
	timeStamp := aDockingBar
				valueOfProperty: #mainDockingBarTimeStamp
				ifAbsent: [^ self].
	timeStamp = self class timeStamp
		ifTrue: [^ self].
	""
	aDockingBar removeAllMorphs.
	self fillDockingBar: aDockingBar