imageFormOfSize: extentPoint depth: d
	| newDisplay |
	newDisplay _ DisplayScreen extent: extentPoint depth: d.
	Display replacedBy: newDisplay do:[
		world isMorph 
			ifTrue:[world fullDrawOn: (Display getCanvas)] "Morphic"
			ifFalse:[world restore]. "MVC"
	].
	^newDisplay