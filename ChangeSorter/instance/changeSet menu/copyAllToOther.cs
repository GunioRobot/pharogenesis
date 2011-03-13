copyAllToOther
	"Copy this entire change set into the one on the other side"
	| other nextToView ii |

	other _ (parent other: self) myChangeSet.
	other assimilateAllChangesFoundIn: myChangeSet.
	(parent other: self) changed: #classList.	"Later the changeSet itself will notice..."
	(parent other: self) changed: #messageList.

	nextToView _ ((AllChangeSets includes: myChangeSet)
			and: [(ii _ AllChangeSets indexOf: myChangeSet) < AllChangeSets size])
		ifTrue: [AllChangeSets at: ii+1]
		ifFalse: [myChangeSet].
	self showChangeSet: nextToView