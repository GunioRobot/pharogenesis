broadcastUpdatesFrom: n1 to: n2 except: skipList
"
	ChangeSorter removeChangeSetsNamedSuchThat:
		[:name | name first isDigit and: [name initialIntegerOrNil > 412]].
	Utilities readServerUpdatesSaveLocally: true updateImage: true.
	Utilities broadcastUpdatesFrom: 413 to: 999 except: #().

	Utilities readServerUpdatesSaveLocally: true updateImage: false
       The expression above ftps all updates not in the current image
over to the local
       hard disk, but does NOT absorb them into the current image
"
	| fileNames fileNamesInOrder fileNamesUnnumbered names choice file
csname updateDirectory |
	updateDirectory _ FileDirectory default directoryNamed: 'updates'.
	fileNames _ updateDirectory fileNames select:
		[:n | n first isDigit
			and: [(n initialIntegerOrNil between: n1 and: n2)
			and: [(skipList includes: n initialIntegerOrNil) not]]].
	fileNamesInOrder _ fileNames asSortedCollection: [:a :b | a
initialIntegerOrNil < b initialIntegerOrNil].
	fileNamesUnnumbered _ fileNamesInOrder collect:
		[:n | n copyFrom: (n findFirst: [:c | c isDigit not]) to: n size].
	(csname _ fileNamesUnnumbered asBag sortedCounts first) key > 1
		ifTrue: [self halt: 'Repeated name: ' , csname value].
	(file _ fileNamesUnnumbered select: [:n | (n occurrencesOf: $.) > 1])
size > 0
		ifTrue: [self halt: file first , ' has multiple periods'].
	fileNamesInOrder with: fileNamesUnnumbered do:
		[:n :nu | updateDirectory rename: n toBe: nu].

	names _ ServerDirectory groupNames asSortedArray.
	choice _ (SelectionMenu labelList: names selections: names) startUp.
	choice == nil ifTrue: [^ self].
	(ServerDirectory groupNamed: choice) putUpdateMulti:
fileNamesUnnumbered fromDirectory: updateDirectory
