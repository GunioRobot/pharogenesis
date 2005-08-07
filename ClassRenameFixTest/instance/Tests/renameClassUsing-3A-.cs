renameClassUsing: aBlock

	| createdClass foundClasses |
	originalName := self newUniqueClassName.
	createdClass := Object 
		subclass: originalName
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'ClassRenameFix-GeneradClass'.
	newClassName := self newUniqueClassName.
	aBlock value: createdClass value: newClassName.
	self assert: (Smalltalk classNamed: originalName) isNil.
	self assert: (Smalltalk classNamed: newClassName) notNil.
	foundClasses := Smalltalk organization listAtCategoryNamed: 'ClassRenameFix-GeneradClass'.
	self assert: (foundClasses notEmpty).
	self assert: (foundClasses includes: newClassName).
	self assert: (createdClass name = newClassName).