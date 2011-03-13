buildMorphicNotifierLabelled: label message: messageString
	| notifyPane window |
	window _ (SystemWindow labelled: label) model: self.

	notifyPane _ PluggableTextMorph on: self text: #contents accept: #doNothing:
		readSelection: #contentsSelection menu: #debugProceedMenu:.
	notifyPane editString: messageString;
		askBeforeDiscardingEdits: false.
	window addMorph: notifyPane frame: (0@0 corner: 1@1).

	^ window openInWorldExtent: 350@116