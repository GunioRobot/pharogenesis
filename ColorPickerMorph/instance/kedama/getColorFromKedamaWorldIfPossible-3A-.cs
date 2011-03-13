getColorFromKedamaWorldIfPossible: aGlobalPoint

	self world submorphs do: [:sub |
		 (sub isKindOf: KedamaMorph) ifTrue: [
			sub morphsAt: aGlobalPoint unlocked: false do: [:e |
				^ e colorAt: (aGlobalPoint - e topLeft).
			].
		].
	].
	^ nil.
