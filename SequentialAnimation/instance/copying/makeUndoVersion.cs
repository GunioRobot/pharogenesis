makeUndoVersion
	"Creates the undo version of an animation"

	| anim copyOfChildren copyOfChild i |

	anim _ SequentialAnimation new.

	i _ 1.
	copyOfChildren _ OrderedCollection new.
	children do: [:child | copyOfChild _ child copy.
						 copyOfChild setLoopCount: (childLoopCounts at: i).
						 copyOfChildren addLast: copyOfChild.
						 i _ i + 1 ].

	anim children: copyOfChildren
		undoable: false
		inWonderland: myWonderland.

	(direction = Reverse) ifTrue: [ anim setDirection: Reverse ].
	anim reverseDirection.

	"Undoing a sequential animation takes 2 seconds"	
	anim scaleDuration: (2 / duration).
	anim stop.

	^ anim.
