cleanUpCategories
	"Prune the dead wood out of all categories."

	self categorizer removeAllSuchThat: [:msgID | (indexFile includesKey: msgID) not].