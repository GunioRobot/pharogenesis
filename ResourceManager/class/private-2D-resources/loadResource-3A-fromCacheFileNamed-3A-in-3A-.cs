loadResource: urlString fromCacheFileNamed: fileName in: dir
	| archiveName file archive |
	(fileName beginsWith: 'zip://') ifTrue:[
		archiveName _ fileName copyFrom: 7 to: fileName size.
		archive _ [dir readOnlyFileNamed: archiveName] 
			on: FileDoesNotExistException
			do:[:ex| ex return: nil].
		archive ifNil:[^nil].
		archive isZipArchive ifTrue:[
			archive _ ZipArchive new readFrom: archive.
			file _ archive members detect:[:any| any fileName = urlString] ifNone:[nil]].
		file ifNotNil:[file _ file contentStream].
		archive close.
	] ifFalse:[
		file _ [dir readOnlyFileNamed: fileName] 
				on: FileDoesNotExistException
				do:[:ex| ex return: nil].
	].
	^file