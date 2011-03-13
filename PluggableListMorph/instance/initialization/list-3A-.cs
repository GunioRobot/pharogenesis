list: listOfStrings
	| morphList handler h loc index |
	scroller removeAllMorphs.
	list _ listOfStrings ifNil: [Array new].
	list isEmpty ifTrue: [^ self selectedMorph: nil].
	"NOTE: we will want a quick StringMorph init message, possibly even
		combined with event install and positioning"
	morphList _ list collect: [:item | StringMorph contents: item].

	"Sensitize first morph and copy handler to all the rest"
	morphList first on: #mouseDown send: #mouseDown:onItem: to: self.
	handler _ morphList first eventHandler.
	morphList do: [:m | m eventHandler: handler].

	"Lay items out vertically and install them in the scroller"
	h _ morphList first height "self listItemHeight".
	loc _ 0@0.
	morphList do: [:m | m bounds: (loc extent: 9999@h).  loc _ loc + (0@h)].
	scroller addAllMorphs: morphList.
	index _ self getCurrentSelectionIndex.
	self selectedMorph: (index = 0 ifTrue: [nil] ifFalse: [morphList at: index]).
	self setScrollDeltas.
	scrollBar setValue: 0.0.