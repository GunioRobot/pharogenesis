unlockedMorphsAt: aPoint addTo: mList
	"Overridden to exclude spurious hits on extralimital submorphs."
	((self containsPoint: aPoint) and: [self isLocked not]) ifTrue:
		[submorphs size > 0 ifTrue:
			[submorphs do: [:m | m unlockedMorphsAt: aPoint addTo: mList]].
		mList addLast: self].
	^ mList