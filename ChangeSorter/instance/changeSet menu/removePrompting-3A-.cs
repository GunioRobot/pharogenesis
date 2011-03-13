removePrompting: doPrompt
	"Completely destroy my change set.  Check if it's OK first,  and if doPrompt is true, get the user to confirm his intentions first"
	| message aName |

	aName _ myChangeSet name.
	myChangeSet okayToRemove ifFalse: [^ self]. "forms current changes for some project"
	(myChangeSet isEmpty or: [doPrompt not]) ifFalse:
		[message _ 'Are you certain that you want to 
remove (destroy) the change set
named  "', aName, '" ?'.
		(self confirm: message) ifFalse: [^ self]].

	"Go ahead and remove the change set"
	AllChangeSets remove: myChangeSet.
	myChangeSet wither.		"clear out its contents"
	self showChangeSet: Smalltalk changes.