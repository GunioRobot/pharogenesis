versionReaderForFileNamed: aString do: aBlock
	^ (self versionReaderForFileNamed: aString) ifNotNilDo: aBlock