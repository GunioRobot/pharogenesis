typeIDFor: anObject
	"Return the typeID for anObject's class."

	| tt |
	tt _ anObject ioType.
	tt == #User ifTrue: [^ 13].	"User Object whose class must be reconstructed"
	(anObject isKindOf: View) ifTrue: [^ 1 "nil"].	"blocked"
	(anObject isKindOf: Controller) ifTrue: [^ 1 "nil"].
	(anObject isKindOf: CompiledMethod) ifTrue: [self halt.  ^ 1 "nil"].
	
	^ TypeMap at: anObject class ifAbsent: [9 "instance"]