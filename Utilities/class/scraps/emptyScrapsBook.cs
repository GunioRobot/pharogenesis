emptyScrapsBook
	"Utilities emptyScrapsBook"
	| oldScraps |
	oldScraps _ ScrapsBook.
	ScrapsBook _ nil.
	self scrapsBook.  "Creates it afresh"
	(oldScraps notNil and: [oldScraps owner notNil])
		ifTrue:
			[ScrapsBook position: oldScraps position.
			oldScraps owner replaceSubmorph: oldScraps by: ScrapsBook.
			ScrapsBook changed; layoutChanged]