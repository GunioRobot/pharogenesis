buildMorphicNotifierLabelled: label message: messageString
	| notifyPane window contentTop extentV |
	window _ (PreDebugWindow labelled: label) model: self.

	"Preferences optionalMorphicButtons" true
		ifTrue:
			[contentTop _ 0.2.
			window addMorph: (self buttonRowForPreDebugWindow: window)
				frame: (0@0 corner: 1 @ contentTop).
			extentV _ 156]
		ifFalse:
			[extentV _ 116.
			contentTop _ 0].
	notifyPane _ PluggableTextMorph on: self text: nil accept: nil
		readSelection: nil menu: #debugProceedMenu:.
	notifyPane editString: messageString; askBeforeDiscardingEdits: false.
	window addMorph: notifyPane frame: (0@contentTop corner: 1@1).

	^ window openInWorldExtent: 450 @ extentV