filesIn: prefix do: aBlock
	| dir filePath |
	dir := prefix inject: FileDirectory default into:[:fd :path| fd directoryNamed: path].
	filePath := prefix inject: '' into:[:zipPath :path| zipPath, path, FileDirectory slash].
	dir fileNames do:[:fName|
		aBlock value: filePath, fName.
	].
	dir directoryNames do:[:dirName|
		self filesIn: (prefix copyWith: dirName) do: aBlock.
	].