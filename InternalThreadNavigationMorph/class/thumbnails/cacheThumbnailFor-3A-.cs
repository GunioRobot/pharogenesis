cacheThumbnailFor: aProject

	| form |

	CachedThumbnails ifNil: [CachedThumbnails _ Dictionary new].
	CachedThumbnails
		at: aProject name
		put: (form _ self sorterFormForProject: aProject sized: nil).
	^form
	