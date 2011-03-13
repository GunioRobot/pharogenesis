forgetAllChangesFoundIn: aChangeSet
	"Remove from the receiver all method changes found in aChangeSet. The intention is facilitate the process of factoring a large set of changes into disjoint change sets.  To use:  in a change sorter, copy over all the changes you want into some new change set, then use the subtract-other-side feature to subtract those changes from the larger change set, and continue in this manner.  (But, remember that if a changeSet says #add, but the method is missing in the image, it won't file out!)"
	| cls itsMethodChanges |
	aChangeSet == self ifTrue: [^ self].

	aChangeSet changedClassNames do: 
		[:className | (cls _ Smalltalk classNamed: className) ~~ nil ifTrue:
				[itsMethodChanges _ aChangeSet methodChanges at: className 
						ifAbsent: [Dictionary new].
				itsMethodChanges associationsDo:
					[:assoc | self undoChange: assoc value for: assoc key class: cls].
						"try to undo the change found in aChangeSet"
				(aChangeSet hasClassChangesFor: className) ifTrue:
					[self removeClassChanges: cls]]].
	classRemoves removeAllFoundIn: aChangeSet classRemoves.	"names of them"
