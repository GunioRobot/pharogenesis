renameCategory: oldName to: newName
	"Rename the given category. This does nothing if the category does not exist or if it is a special category ('.all.' or '.unclassified.')."

	categoriesFile renameCategory: oldName to: newName.
