removeUserClassesFromChanges
	"Remove from the current ChangeSet all user-spawned classes, which are recognized by the fact their names end in digits"

	"Utiliies removeUserClassesFromChanges"

	(Object withAllSubclasses select: [:c | c name endsWithDigit]) do:
		[:aClass | aClass removeFromChanges]