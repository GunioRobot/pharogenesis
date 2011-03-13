openServer
	"make me show a directory on some remote FTP server.  directory will be a ServerDirectory, file will be a ServerFile.  stream will be a RWBinaryOrTextStream"

	| selectors reply |
	list _ ServerDirectory servers.
	selectors _ (list collect: [:assoc | assoc key]) asSortedArray.
	reply _ (SelectionMenu labelList: selectors selections: selectors) startUp.
	reply == nil ifTrue: [^ self].
	self directory: (list detect: [:assoc | assoc key == reply]) value.