mouseLeave: evt
	"Clear drag/drop feedback."

	color ~= (TilePadMorph colorForType: type) ifTrue: [
		self color: (TilePadMorph colorForType: type).
		self submorphsDo: [:subM |
			(subM isKindOf: TileMorph) ifTrue: [
				subM color: (TilePadMorph unbrightColorFor: subM color)]]].
