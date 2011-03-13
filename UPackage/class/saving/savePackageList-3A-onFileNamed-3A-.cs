savePackageList: packageList  onFileNamed: filename
	| tmpName file |
	tmpName _ filename, 'tmp'.
	FileDirectory default deleteFileNamed: tmpName ifAbsent:  [].

	file _ FileStream fileNamed: tmpName.
	packageList do: [ :package |
		file nextPutAll: package xmlForExport ].
	file close.

	FileDirectory default rename: tmpName toBe: filename.
