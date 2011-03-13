assignStatusToAllSiblings
	"Let all sibling instances of my player have the same status that I do"

	(player class allInstances copyWithout: player) do:
		[:aPlayer |
			(aPlayer scriptInstantiationForSelector: selector) status: status]