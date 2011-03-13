printOn: aStream

	aStream nextPutAll: 'Cfg['.
	requiredReleases do: [:r |
		aStream nextPutAll: r printString; space].
	aStream nextPutAll: ']'