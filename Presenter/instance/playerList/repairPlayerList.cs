repairPlayerList
	"Presenter allInstancesDo: [:p | p repairPlayerList]"
	playerList ifNotNil:
		[playerList _ playerList select: [:p | p isKindOf: Player]]