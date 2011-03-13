forgetAllChangesFoundIn: aChangeSet
	"Remove from the receiver all method changes found in aChangeSet. The intention is facilitate the process of factoring a large set of changes into disjoint change sets.  3/13/96 sw.  Note that class-(re)-definition changes are not subtracted out, yet."

	| cls itsMethodChanges |

	aChangeSet == self ifTrue: [^ self].

	aChangeSet changedClassNames do:
		[:className | (cls _ Smalltalk classNamed: className) ~~ nil
			ifTrue:
				[itsMethodChanges _ aChangeSet methodChanges at: className  ifAbsent: [Dictionary new].
				itsMethodChanges associationsDo:
					[:assoc | self removeSelectorChanges:  assoc key class: cls]]]