storeAll
	"Write all Environments except me and the top one out as image segments."

	| firstToGo others |
	firstToGo _ #(VMConstruction Morphic Sound Network Balloon)
					collect: [:x | Smalltalk at: x].
	others _ Smalltalk values select:
		[:value |  (value isKindOf: Environment)
					and: [(firstToGo includes: value) not & (value ~~ Smalltalk)]].
	firstToGo , others do: [:anEnv | anEnv storeSegment].