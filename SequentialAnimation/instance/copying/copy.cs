copy
	"Creates a copy of the animation"

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

	^ anim.
