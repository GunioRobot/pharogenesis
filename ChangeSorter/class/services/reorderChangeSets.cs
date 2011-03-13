reorderChangeSets
	"ChangeSorter reorderChangeSets"
	"Change the order of the change sets to something more convenient:
		First come the unnumbered changesets that come with the release.
		Next come the numbered updates.
		Next come all remaining changesets
	In a ChangeSorter, they will appear in the reversed order."

	| newHead newMid newTail itsName |

	self gatherChangeSets.
	newHead _ OrderedCollection new.
	newMid _ OrderedCollection new.
	newTail _ OrderedCollection new.
	AllChangeSets do:
		[:aSet |
			itsName _ aSet name.
			((itsName beginsWith:  'Play With Me') or: [#('New Changes' 'MakeInternal') includes: itsName])
				ifTrue:
					[newHead add: aSet]
				ifFalse:
					[itsName startsWithDigit
						ifTrue:
							[newMid add: aSet]
						ifFalse:
							[newTail add: aSet]]].
	AllChangeSets _ newHead, newMid, newTail.
	Smalltalk isMorphic ifTrue: [SystemWindow wakeUpTopWindowUponStartup]