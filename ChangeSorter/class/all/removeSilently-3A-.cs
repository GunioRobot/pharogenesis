removeSilently: aChangeSet
	"Remove the given change set from the system silently; return true if the removal succeeded, or false if the change set was locked down for some reason."
	aChangeSet belongsToAProject ifTrue: [^ false].
	AllChangeSets remove: aChangeSet.
	aChangeSet wither.
	^ true
"
Handy code to drop all but most recent N changeSets...
 | allChanges |  allChanges _ ChangeSorter gatherChangeSets.
(allChanges copyFrom: 1 to: (allChanges size - 40 max: 0))
	do: [:oldSet | ChangeSorter removeSilently: oldSet]
"