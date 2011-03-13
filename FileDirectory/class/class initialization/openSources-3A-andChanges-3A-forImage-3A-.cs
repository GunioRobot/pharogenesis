openSources: sourcesName andChanges: changesName forImage: imageName
	"Look for the changes file on the image volume, and make the image volume the default directory.  Then look for the sources in the image volume.   Install results in SourceFiles.  2/13/96 sw."
	| sources changes |
	self setDefaultDirectoryFrom: imageName.
	sources _ (DefaultDirectory includesKey: sourcesName)
		ifTrue: [DefaultDirectory readOnlyFileNamed: sourcesName]
		ifFalse: [nil].
	changes _ (DefaultDirectory includesKey: changesName)
		ifTrue: [DefaultDirectory oldFileNamed: changesName]
		ifFalse: [nil].
	SourceFiles _ Array with: sources with: changes