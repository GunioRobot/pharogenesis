is: oop KindOf: className
	"Support for external primitives."
	| oopClass |
	self var: #className declareC:'char *className'.
	oopClass _ self fetchClassOf: oop.
	[oopClass == nilObj] whileFalse:[
		(self classNameOf: oopClass Is: className) ifTrue:[^true].
		oopClass _ self superclassOf: oopClass].
	^false