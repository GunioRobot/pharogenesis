loadNotes
	"Load notes from the files"
	| dir |

	names _ OrderedCollection new.
	notes _ OrderedCollection new.
	(FileDirectory default directoryExists: 'audio')
		ifFalse: [FileDirectory default createDirectory: 'audio'].
	dir _ self audioDirectory.
	dir fileNames do: [:fname |
		(fname endsWith: '.name') ifTrue: [
			names add: ((dir fileNamed: fname) contentsOfEntireFile).
			notes add: (fname copyFrom: 1 to: (fname size - 4))]].