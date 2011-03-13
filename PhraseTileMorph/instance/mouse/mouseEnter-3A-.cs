mouseEnter: evt
	"Show drag/drop feedback."

	| h m |
	h _ evt hand.
	h submorphCount ~= 1 ifTrue: [^ self].
	m _ h firstSubmorph.
	(self canAccept: m) ifFalse: [^ self].
	"don't give feedback if I'm not the inner-most phrase that could be replaced"
	(self morphsAt: evt cursorPoint) do: [:subM |
		((subM isKindOf: PhraseTileMorph) and: [subM ~~ self]) ifTrue: [^ self].
		(subM isKindOf: TilePadMorph) ifTrue: [^ self]].

	self brightenTiles.
