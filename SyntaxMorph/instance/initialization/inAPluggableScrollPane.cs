inAPluggableScrollPane
	"Answer a PluggableTileScriptorMorph that holds the receiver"

	| widget |
	widget := PluggableTileScriptorMorph new.
	widget extent: 10@10; borderWidth: 0.
	widget scroller addMorph: self.
	widget setScrollDeltas.
	widget hResizing: #spaceFill; vResizing: #spaceFill.
	^ widget

