getThumbnailFor: aProject

	CachedThumbnails ifNil: [CachedThumbnails _ Dictionary new].
	^CachedThumbnails
		at: aProject name
		ifAbsentPut: [self sorterFormForProject: aProject sized: nil]