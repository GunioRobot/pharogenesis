copyAllToOther
	"Copy this entire change set into the one on the other side"
	| companionSorter |
	self checkThatSidesDiffer: [^ self].
	(companionSorter _ parent other: self) changeSetCurrentlyDisplayed assimilateAllChangesFoundIn: myChangeSet.
	companionSorter changed: #classList.	"Later the changeSet itself will notice..."
	companionSorter changed: #messageList