classNameOf: aClass Is: className
	"Check if aClass' name is className"
	| name |
	(self lengthOf: aClass) <= 6 ifTrue:[^false]. "Not a class but maybe behavior" 
	name _ self fetchPointer: 6 ofObject: aClass.
	(self isBytes: name) ifFalse:[^false].
	^ className = (self stringOf: name).
