indexForInserting: aMorph at: aPoint in: owner
	"Return the insertion index based on the layout strategy defined for some morph. Used for drop insertion."
	| horizontal morphList index |
	owner hasSubmorphs ifFalse:[^1].
	aMorph disableTableLayout ifTrue:[^1].
	(owner listDirection == #topToBottom or:[owner listDirection == #bottomToTop])
		ifTrue:[	horizontal _ false]
		ifFalse:[	horizontal _ true].
	morphList _ owner submorphs.
	owner reverseTableCells ifTrue:[morphList _ morphList reversed].
	index _ self indexForInserting: aPoint inList: morphList horizontal: horizontal target: owner.
	owner reverseTableCells ifTrue:[index _ morphList size - index + 2].
	^index ifNil:[1].			