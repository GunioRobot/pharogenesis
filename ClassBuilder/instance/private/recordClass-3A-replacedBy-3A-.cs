recordClass: oldClass replacedBy: newClass
	"Record the replacement of oldClass by newClass so that we can
	fix any references to oldClass later on."
	classMap at: newClass put: oldClass.
	(classMap includesKey: oldClass) ifTrue:[
		"This will happen if we recompile from Class
		in which case the metaclass gets recorded twice"
		classMap at: newClass put: (classMap at: oldClass).
		classMap removeKey: oldClass.
	].
	"And keep the changes up to date"
	(instVarMap includesKey: oldClass name) ifTrue:[
		Smalltalk changes changeClass: newClass from: oldClass.
	].