openDB
	"Open an existing mail database."

	Transcript show: 'Opening mail database ''', rootFilename, '''...'.
	messageFile _ MessageFile openOn: rootFilename, '.messages'.
	indexFile _ IndexFile openOn: rootFilename, '.index' messageFile: messageFile.
	categoriesFile _ CategoriesFile openOn: rootFilename, '.categories'.
	Transcript show: 'Done.'; cr.