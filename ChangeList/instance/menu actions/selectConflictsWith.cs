selectConflictsWith
	"Selects all method definitions for which there is ALSO an entry in the specified changeSet or changList chosen by the user. 4/11/96 tk"
	| aStream all index  coll |
	aStream _ WriteStream on: (String new: 200).
	all _ ChangeSet allInstances.
	all do:
		[:sel | aStream nextPutAll: (sel name contractTo: 40); cr].
	coll _ ChangeList allInstances.
	coll do:
		[:sel | aStream nextPutAll: (sel file name); cr.
			all addLast: sel].
	aStream skip: -1.
	index _ (PopUpMenu labels: aStream contents) startUp.
	index > 0 ifTrue: [
		self selectConflicts: (all at: index)].