selectionIndex: index 
	"Called internally to select the index-th item."
	| theMorph range |
	(index isNil
			or: [index > scroller submorphs size])
		ifTrue: [^ self].
	(theMorph _ index = 0
				ifFalse: [scroller submorphs at: index])
		ifNotNil: [(theMorph bounds top - scroller offset y >= 0
					and: [theMorph bounds bottom - scroller offset y <= bounds height])
				ifFalse: ["Scroll into view -- should be elsewhere"
					range _ self leftoverScrollRange.
					scrollBar
						value: (range > 0
								ifTrue: [index - 1 * theMorph height / self leftoverScrollRange truncateTo: scrollBar scrollDelta]
								ifFalse: [0]).
					scroller offset: -3 @ (range * scrollBar value)]].
	"Save the selection index to make it easy to do the highlighting work  
	later."
	selectedIndex _ index.
	self selectedMorph: theMorph