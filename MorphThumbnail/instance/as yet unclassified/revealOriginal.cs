revealOriginal
	((owner isKindOf: PasteUpMorph) and: [owner alwaysShowThumbnail])
		ifTrue:
			[^ self beep].
	morphRepresented owner == nil ifTrue:
		[^ owner replaceSubmorph: self by: morphRepresented].
	self beep.