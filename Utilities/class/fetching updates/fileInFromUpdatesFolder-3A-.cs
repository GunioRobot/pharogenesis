fileInFromUpdatesFolder: numberList
	"File in a series of updates with the given updates numbers, from the updates folder in the default directory.  The file-ins are done in numeric order, even if numberList was not sorted upon entry.
	This is useful for test-driving the retrofitting of a possibly discontinguous list of updates from an alpha version back to a stable release.

	Utilities fileInFromUpdatesFolder: #(4745 4746 4747 4748 4749 4750 4751 4752 4754 4755 4761 4762 4767 4769).
"
	| fileNames fileNamesInOrder file updateDirectory |
	updateDirectory _ FileDirectory default directoryNamed: 'updates'.
	fileNames _ updateDirectory fileNames select:
		[:n | n first isDigit
			and: [numberList includes: n initialIntegerOrNil]].
	(file _ fileNames select: [:n | (n occurrencesOf: $.) > 1]) size > 0
		ifTrue: [self error: file first , ' has multiple periods'].
	fileNamesInOrder _ fileNames asSortedCollection:
		[:a :b | a initialIntegerOrNil < b initialIntegerOrNil].

	fileNamesInOrder do:
		[:aFileName | (updateDirectory readOnlyFileNamed: aFileName) fileIntoNewChangeSet]