mouseEnter: evt
	"Show drag/drop feedback."

	| h m |
	h _ evt hand.
	h submorphCount ~= 1 ifTrue: [^ self].
	m _ h firstSubmorph.
	(self canAccept: m) ifTrue:
		[self color: (ScriptingSystem brightColorForType: type).
		self submorphsDo: [:subM |
			(subM isKindOf: TileMorph) ifTrue:
				[subM color: (ScriptingSystem brightColorFor: subM color)]]].
