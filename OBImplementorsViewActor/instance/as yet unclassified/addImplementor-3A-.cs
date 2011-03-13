addImplementor: aNode 
	| class sel |
	sel := aNode selector.
	class := self getClassForNewImplementationOf: sel.
	class ifNil: [^self].
	(class selectors includes: sel) 
		ifTrue: [^self inform: class name , ' already implements #' , sel].
	class compile: aNode selector , '
	self shouldBeImplemented'.
	(OBMethodNode on: sel inClass: class) signalSelection