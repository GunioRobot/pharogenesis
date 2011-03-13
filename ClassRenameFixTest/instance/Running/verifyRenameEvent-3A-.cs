verifyRenameEvent: aRenamedEvent

	| renamedClass |
	self assert: aRenamedEvent isRenamed.
	renamedClass :=  aRenamedEvent item.
	self assert: (Smalltalk classNamed: newClassName) name = newClassName.
	self assert: renamedClass name = newClassName