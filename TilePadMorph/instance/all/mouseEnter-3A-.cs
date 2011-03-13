mouseEnter: evt
	"Show drag/drop feedback."

	| h m |
	h _ evt hand.
	h submorphCount ~= 1 ifTrue: [^ self].
	m _ h firstSubmorph.
	(self canAccept: m) ifTrue: [
		self color: (TilePadMorph brightColorForType: type).
		self submorphsDo: [:subM |
			(subM isKindOf: TileMorph) ifTrue: [
				subM color: (TilePadMorph brightColorFor: subM color)]]].
