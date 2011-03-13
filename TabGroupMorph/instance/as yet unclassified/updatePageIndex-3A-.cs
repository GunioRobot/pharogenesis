updatePageIndex: index
	"Change to the given page index."

	|p|
	p := self pageMorph.
	p isNil
		ifTrue: [self contentMorph addMorph: (self pages at: index)]
		ifFalse: [self contentMorph
				replaceSubmorph: p
				by: (self pages at: index)].
	self pageMorph layoutChanged.
	self adoptPaneColor: (self owner ifNil: [self]) paneColor