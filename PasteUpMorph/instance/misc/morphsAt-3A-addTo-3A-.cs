morphsAt: aPoint addTo: mList
	"Overridden to exclude spurious hits on extralimital submorphs."
	(self containsPoint: aPoint) ifTrue:
		[submorphs size > 0 ifTrue:
			[submorphs do: [:m | m morphsAt: aPoint addTo: mList]].
		mList addLast: self].
	^ mList