submergeIntoOtherSide
	"Copy the contents of the receiver to the other side, then remove the receiver -- all after checking that all is well."
	| other message nextToView i |

	self okToChange ifFalse: [^ self].
	other _ (parent other: self) changeSet.
	other == myChangeSet ifTrue: [^ self inform: 'Both sides are the same!'].
	myChangeSet isEmpty ifTrue: [^ self inform: 'Nothing to copy.  To remove,
simply choose "remove".'].

	myChangeSet okayToRemove ifFalse: [^ self].
	message _ 'Please confirm:  copy all changes
in "', myChangeSet name, '" into "', other name, '"
and then destroy the change set
named "', myChangeSet name, '"?'.
 
	(self confirm: message) ifFalse: [^ self].
	other assimilateAllChangesFoundIn: myChangeSet.

	nextToView _ ((AllChangeSets includes: myChangeSet)
		and: [(i _ AllChangeSets indexOf: myChangeSet) < AllChangeSets size])
		ifTrue: [AllChangeSets at: i+1]
		ifFalse: [other].

	self removePrompting: false.
	self showChangeSet: nextToView.
	self class gatherChangeSets.
	(parent other: self) changed: #classList.
	(parent other: self) changed: #messageList.