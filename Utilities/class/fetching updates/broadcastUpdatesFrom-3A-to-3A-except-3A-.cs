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
	updateDirectory := FileDirectory default directoryNamed: 'updates'.
	fileNames := updateDirectory fileNames select:
		[:n | n first isDigit
			and: [(n initialIntegerOrNil between: n1 and: n2)
			and: [(skipList includes: n initialIntegerOrNil) not]]].
	(file := fileNames select: [:n | (n occurrencesOf: $.) > 1]) size > 0
		ifTrue: [self halt: file first , ' has multiple periods'].
	fileNamesInOrder := fileNames asSortedCollection:
		[:a :b | a initialIntegerOrNil < b initialIntegerOrNil].

	names := ServerDirectory groupNames asSortedArray.
	choice := UIManager default chooseFrom: names values: names.
	choice ifNil: [^ self].
	(ServerDirectory serverInGroupNamed: choice)
		putUpdateMulti: fileNamesInOrder fromDirectory: updateDirectory
