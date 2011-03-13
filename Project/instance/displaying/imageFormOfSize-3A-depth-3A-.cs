imageFormOfSize: extentPoint depth: d
	| newDisplay |
	newDisplay _ DisplayScreen extent: extentPoint depth: d.
	Display replacedBy: newDisplay do:[
		world isMorph 
			ifTrue:[Display getCanvas fullDrawMorph: world] "Morphic"
			ifFalse:[world restore]. "MVC"
	].
	^newDisplay