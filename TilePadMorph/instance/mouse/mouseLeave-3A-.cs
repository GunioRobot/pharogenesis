mouseLeave: evt
	"Clear drag/drop feedback."

	color ~= (ScriptingSystem colorForType: type) ifTrue:
		[self color: (ScriptingSystem colorForType: type).
		self submorphsDo: [:subM |
			(subM isKindOf: TileMorph) ifTrue:
				[subM color: (ScriptingSystem unbrightColorFor: subM color)]]].
