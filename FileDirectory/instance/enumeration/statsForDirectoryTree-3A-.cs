statsForDirectoryTree: rootedPathName
	"Return the size statistics for the entire directory tree starting at the given root. The result is a three element array of the form: (<number of folders><number of files><total bytes in all files>). This method also serves as an example of how recursively enumerate a directory tree."
	"FileDirectory default statsForDirectoryTree: 'Black Uhuru:System Folder'"

	| dirs files bytes todo p entries |
	dirs _ files _ bytes _ 0.
	todo _ OrderedCollection with: rootedPathName.
	[todo isEmpty] whileFalse: [
		p _ todo removeFirst.
		entries _ self directoryContentsFor: p.
		entries do: [:entry |
			(entry at: 4)
				ifTrue: [
					todo addLast: (p, ':', (entry at: 1)).
					dirs _ dirs + 1]
				ifFalse: [
					files _ files + 1.
					bytes _ bytes + (entry at: 5)]]].

	^ Array with: dirs with: files with: bytes
