openFileDirectly
	| file |
	(file _ StandardFileMenu oldFile) ifNotNil:
		[(FileList openMorphOn: (file directory readOnlyFileNamed: file name) editString: nil)
			openInWorld: self world]