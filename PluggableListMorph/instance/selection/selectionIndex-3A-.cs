selectionIndex: index
	"Called internally to select the index-th item."
	| theMorph range |
	index ifNil: [^ self].
	(theMorph _ index = 0 ifTrue: [nil] ifFalse: [scroller submorphs at: index])
		ifNotNil:
		[((theMorph bounds top - scroller offset y) >= 0
			and: [(theMorph bounds bottom - scroller offset y) <= bounds height]) ifFalse:
			["Scroll into view -- should be elsewhere"
			range _ self totalScrollRange.
			scrollBar value: (range > 0
				ifTrue: [((index-1 * theMorph height) / self totalScrollRange)
									truncateTo: scrollBar scrollDelta]
				ifFalse: [0]).
			scroller offset: -3 @ (range * scrollBar value)]].
	self selectedMorph: theMorph