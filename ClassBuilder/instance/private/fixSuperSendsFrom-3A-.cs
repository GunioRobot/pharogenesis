fixSuperSendsFrom: oldClass
	"The oldClass is about to be removed from the environment.
	Fix all references to super so that the association is different from
	the original ST association."
	| newSuper nLits lastLiteral |
	newSuper _ Association key: nil value: oldClass.
	oldClass methodsDo:[:meth|
		nLits _ meth numLiterals.
		nLits > 0 
			ifTrue:[lastLiteral _ meth literalAt: nLits]
			ifFalse:[lastLiteral _ nil].
		(lastLiteral class == Association and:[meth sendsToSuper]) ifTrue:[
			meth literalAt: nLits put: newSuper.
		].
	].