cachedImageAt: aKey ifAbsentPut: aBlock

	CachedImages ifNil: [CachedImages _ Dictionary new].
	^CachedImages at: aKey ifAbsentPut: aBlock