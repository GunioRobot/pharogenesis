renameCategory: oldName to: newName 
	| oldEntry |
	((self pseudoCategories includes: oldName) or: [self allCategories includes: newName]) ifTrue: [^ self].
	oldEntry _ categories removeKey: oldName ifAbsent: [self newCategory].
	categories at: newName put: oldEntry.