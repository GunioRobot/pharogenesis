fixSuperSendsTo: newClass
	"The newClass has been exported into the environment.
	Fix all references to super so that the association is
	the original ST association."
	| newSuper nLits lastLiteral |
	newSuper _ Smalltalk associationAt: newClass name ifAbsent:[nil].
	newSuper == nil ifTrue:[^self].
	newSuper value == newClass ifTrue:[^self].
	newClass methodsDo:[:meth|
		nLits _ meth numLiterals.
		nLits > 0 
			ifTrue:[lastLiteral _ meth literalAt: nLits]
			ifFalse:[lastLiteral _ nil].
		(lastLiteral class == Association and:[meth sendsToSuper]) ifTrue:[
			meth literalAt: nLits put: newSuper.
		].
	].