renameCategory: oldName to: newName 
	"Rename the given category."
	| oldEntry |
	oldName = '.all.' | oldName = '.unclassified.' | (self categories includes: newName) ifTrue: [^ self].
	"can't rename a special category or overwrite an existing one"
	oldEntry _ categories removeKey: oldName ifAbsent: [PluggableSet integerSet].
	categories at: newName put: oldEntry