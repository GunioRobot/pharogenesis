bestAccessToFileName: aFileName andDirectory: aDirectoryOrURL

	| localDir schema dir |

	((localDir _ Project squeakletDirectory) fileExists: aFileName)
		ifTrue: [^{localDir readOnlyFileNamed: aFileName. localDir}].

	(aDirectoryOrURL isString) 
		ifTrue: [
			schema := Url schemeNameForString: aDirectoryOrURL.
			(schema isNil or: [schema = 'file'])
				ifTrue: [
					dir := schema
						ifNil: [FileDirectory forFileName: (FileDirectory default fullNameFor: aDirectoryOrURL)]
						ifNotNil: [FileDirectory on: ((FileUrl absoluteFromText: aDirectoryOrURL) pathForDirectory)]]
				ifFalse: [^{(Project serverFileFromURL: aDirectoryOrURL) asStream. nil}]]
		ifFalse: [dir := aDirectoryOrURL].

	^{dir readOnlyFileNamed: aFileName. dir}
