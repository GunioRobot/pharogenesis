resetUniqueInstance
	"self resetUniqueInstance"

	UniqueInstance
		ifNotNilDo: [:u | UniqueInstance releaseAll.
			UniqueInstance _ nil]