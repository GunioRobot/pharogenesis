testRenameClassUsingSystemDictionary
	"self run: #testRenameClassUsingSystemDictionary"

	self renameClassUsing: [:class :newName | Smalltalk renameClass: class as: newName].