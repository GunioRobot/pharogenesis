list: listOfStrings  
	"lex doesn't think this is used any longer, but is not yet brave enough to remove it.  It should be removed eventually"
	
	
	"Set the receiver's list as specified"

	| morphList h loc index converter item aSelector textColor font |
	scroller removeAllMorphs.
	list _ listOfStrings ifNil: [Array new].
	list isEmpty ifTrue: [self setScrollDeltas.  ^ self selectedMorph: nil].
	"NOTE: we will want a quick StringMorph init message, possibly even
		combined with event install and positioning"
	font ifNil: [font _ Preferences standardListFont].
	converter _ self valueOfProperty: #itemConversionMethod.
	converter ifNil: [converter _ #asStringOrText].
	textColor _ self valueOfProperty: #textColor.
	morphList _ list collect: [:each | | stringMorph |
		item _ each.
		item _ item perform: converter.
		stringMorph _ item isText
			ifTrue: [StringMorph contents: item font: font emphasis: (item emphasisAt: 1)]
			ifFalse: [StringMorph contents: item font: font].
		textColor ifNotNil: [ stringMorph color: textColor ].
		stringMorph
	].
	
	(aSelector _ self valueOfProperty: #balloonTextSelectorForSubMorphs)
		ifNotNil:
			[morphList do: [:m | m balloonTextSelector: aSelector]].

	self highlightSelector ifNotNil:
		[model perform: self highlightSelector with: list with: morphList].

	"Lay items out vertically and install them in the scroller"
	h _ morphList first height "self listItemHeight".
	loc _ 0@0.
	morphList do: [:m | m bounds: (loc extent: 9999@h).  loc _ loc + (0@h)].
	scroller addAllMorphs: morphList.

	index _ self getCurrentSelectionIndex.
	self selectedMorph: ((index = 0 or: [index > morphList size]) ifTrue: [nil] ifFalse: [morphList at: index]).
	self setScrollDeltas.
	scrollBar setValue: 0.0