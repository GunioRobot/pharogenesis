renameClass: aClass from: oldName 
	"Rename the class, aClass, to have the title newName."
	| oldref i newName category |
	newName := aClass name.
	category := SystemOrganization categoryOfElement: oldName.
	SystemOrganization classify: newName under: category.
	SystemOrganization removeElement: oldName.
	oldref := self associationAt: oldName.
	self removeKey: oldName.
	oldref key: newName.
	self add: oldref.  "Old association preserves old refs"
	(Array with: StartUpList with: ShutDownList) do:
		[:list |  i := list indexOf: oldName ifAbsent: [0].
		i > 0 ifTrue: [list at: i put: newName]].
	self flushClassNameCache.

	SystemChangeNotifier uniqueInstance classRenamed: aClass from: oldName to: newName inCategory: category