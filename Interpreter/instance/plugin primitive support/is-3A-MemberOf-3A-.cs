is: oop MemberOf: className
	"Support for external primitives"
	| oopClass |
	self var: #className declareC:'char *className'.
	oopClass _ self fetchClassOf: oop.
	^(self classNameOf: oopClass Is: className)