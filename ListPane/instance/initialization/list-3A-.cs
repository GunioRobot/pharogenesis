list: listOfStrings
	| morphList handler h loc |
	scroller removeAllMorphs.
	scrollBar setValue: 0.0.
	listOfStrings isEmpty ifTrue: [^ self setSelectedMorph: nil].
	"NOTE: we will want a quick StringMorph init message, possibly even
		combined with event install and positioning"
	morphList _ listOfStrings collect: [:item | StringMorph contents: item].

	"Sensitize first morph and copy handler to all the rest"
	morphList first on: #mouseDown send: #mouseDown:onItem: to: self.
	handler _ morphList first eventHandler.
	morphList do: [:m | m eventHandler: handler].

	"Lay items out vertically and install them in the scroller"
	h _ morphList first height "self listItemHeight".
	loc _ 0@0.
	morphList do: [:m | m bounds: (loc extent: 9999@h).  loc _ loc + (0@h)].
	scroller addAllMorphs: morphList.
	self setSelectedMorph: nil.
	self setScrollDeltas