createTextPaneExtent: answerExtent acceptBoolean: acceptBoolean topOffset: topOffset buttonAreaHeight: buttonAreaHeight 
	"create the textPane"
	| result frame |
	result := PluggableTextMorph
				on: self
				text: #response
				accept: #response:
				readSelection: #selectionInterval
				menu: #codePaneMenu:shifted:.
	result extent: answerExtent.
	result hResizing: #spaceFill;
		 vResizing: #spaceFill.
	result borderWidth: 1.
	result hasUnacceptedEdits: true.
	result acceptOnCR: acceptBoolean.
	result setNameTo: 'textPane'.
	frame := LayoutFrame new.
	frame leftFraction: 0.0;
		 rightFraction: 1.0;
		 topFraction: 0.0;
		 topOffset: topOffset;
		 bottomFraction: 1.0;
		 bottomOffset: buttonAreaHeight negated.
	result layoutFrame: frame.
	self addMorph: result.
	^ result