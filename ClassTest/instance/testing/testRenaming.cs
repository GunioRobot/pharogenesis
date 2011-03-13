testRenaming
	| oldName newName newMetaclassName class |
	oldName := className.
	newName := #RenamedTUTU.
	newMetaclassName := (newName, #' class') asSymbol.
	class := Smalltalk at: oldName.
	class class compile: 'dummyMeth'.
	class rename: newName.
	className := class name. "Important for tearDown"
	self assert: class name = newName.
	self assert: (ChangeSet current changedClassNames includes: newName). 
	self assert: (ChangeSet current changedClassNames includes: newMetaclassName).
	