openDB
	"Open an existing mail database."

	Transcript show: 'Opening mail database ''', rootFilename, '''...'.
	messageFile _ MessageFile openOn: rootFilename, '.messages'.
	indexFile _ IndexFile openOn: rootFilename, '.index' messageFile: messageFile readLogFlag: true.
	categoriesFile _ CategoriesFile openOn: rootFilename, '.categories'.
	self spamFilter. "Open spam filter file, if necessary."
	Transcript show: 'Done.'; cr.