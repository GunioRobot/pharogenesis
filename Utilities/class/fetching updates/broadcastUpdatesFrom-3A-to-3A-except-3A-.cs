broadcastUpdatesFrom: n1 to: n2 except: skipList
"
	Note:  This method takes its list of files from the directory named 'updates',
	which will have been created and filled by, eg,
		Utilities readServerUpdatesSaveLocally: true updateImage: true.
	These can then be rebroadcast to any server using, eg,
		Utilities broadcastUpdatesFrom: 1 to: 9999 except: #(223 224).
	If the files are already on the server, and it is only a matter
	of copying them to the index for a different version, then use...
		(ServerDirectory serverInGroupNamed: 'SqC Internal Updates*')
			exportUpdatesExcept: #().
"
	| fileNames fileNamesInOrder names choice file updateDirectory |
	updateDirectory _ FileDirectory default directoryNamed: 'updates'.
	fileNames _ updateDirectory fileNames select:
		[:n | n first isDigit
			and: [(n initialIntegerOrNil between: n1 and: n2)
			and: [(skipList includes: n initialIntegerOrNil) not]]].
	(file _ fileNames select: [:n | (n occurrencesOf: $.) > 1]) size > 0
		ifTrue: [self halt: file first , ' has multiple periods'].
	fileNamesInOrder _ fileNames asSortedCollection:
		[:a :b | a initialIntegerOrNil < b initialIntegerOrNil].

	names _ ServerDirectory groupNames asSortedArray.
	choice _ (SelectionMenu labelList: names selections: names) startUp.
	choice == nil ifTrue: [^ self].
	(ServerDirectory serverInGroupNamed: choice)
		putUpdateMulti: fileNamesInOrder fromDirectory: updateDirectory
