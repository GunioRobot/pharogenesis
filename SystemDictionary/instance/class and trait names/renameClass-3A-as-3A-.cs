renameClass: aClass as: newName 
	"Rename the class, aClass, to have the title newName."
	| oldref i oldName category |
	oldName := aClass name.
	category := aClass category.
	SystemOrganization classify: newName under: aClass category.
	SystemOrganization removeElement: aClass name.
	oldref _ self associationAt: aClass name.
	self removeKey: aClass name.
	oldref key: newName.
	self add: oldref.  "Old association preserves old refs"
	(Array with: StartUpList with: ShutDownList) do:
		[:list |  i _ list indexOf: aClass name ifAbsent: [0].
		i > 0 ifTrue: [list at: i put: newName]].
	self flushClassNameCache.
	SystemChangeNotifier uniqueInstance classRenamed: aClass from: oldName to: newName inCategory: category