remove
	"Completely destroy my change set.  Check if it's OK first.  tck 1991
	 1/22/96 sw MacPal -> Utilities.  2/7/96 sw: changed the order of the various checks; don't put up confirmer if the change set is empty"

	| message |

	myChangeSet == Smalltalk changes ifTrue:
		[self inform: 'Cannot remove the 
current change set.'.
		^ self].

	Project allInstances do: [:each |
		each projectChangeSet == myChangeSet ifTrue:
			[Utilities inform: 'This change set belongs to a 
project and cannot be removed.'.
			^ self]].

	myChangeSet isEmpty ifFalse:
		[message _ 'Are you certain that you want to 
forget all the changes in this set?'.
		(self confirm: message) ifFalse: [^ self]].

	"Go ahead and remove the change set"
	AllChangeSets remove: myChangeSet.
	myChangeSet wither.		"clear out its contents"
	"Show the current change set"
	myChangeSet _ Smalltalk changes.
	buttonView label: myChangeSet name asParagraph.
	buttonView display.
	self changed: #set