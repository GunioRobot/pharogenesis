class: oldClass instanceVariableNames: instVarString unsafe: unsafe
	"This is the basic initialization message to change the definition of
	an existing Metaclass"
	| instVars newClass |
	environ _ oldClass environment.
	instVars _ Scanner new scanFieldNames: instVarString.
	unsafe ifFalse:[
		"Run validation checks so we know that we have a good chance for recompilation"
		(self validateInstvars: instVars from: oldClass forSuper: oldClass superclass) ifFalse:[^nil].
		(self validateSubclassFormat: oldClass typeOfClass from: oldClass forSuper: oldClass superclass extra: instVars size) ifFalse:[^nil]].
	"Create a template for the new class (will return oldClass when there is no change)"
	newClass _ self 
		newSubclassOf: oldClass superclass 
		type: oldClass typeOfClass
		instanceVariables: instVars
		from: oldClass
		unsafe: unsafe.

	newClass == nil ifTrue:[^nil]. "Some error"
	newClass _ self recompile: false from: oldClass to: newClass mutate: false.
	self doneCompiling: newClass.
	^newClass