buildMorphicNotifierLabelled: label message: messageString
	| notifyPane window contentTop extentToUse |
	self expandStack.
	window _ (PreDebugWindow labelled: label) model: self.

	contentTop _ 0.2.
	extentToUse _ 450 @ 156. "nice and wide to show plenty of the error msg"
	window addMorph: (self buttonRowForPreDebugWindow: window)
				frame: (0@0 corner: 1 @ contentTop).

	Preferences eToyFriendly | messageString notNil
		ifFalse:
			[notifyPane _ PluggableListMorph on: self list: #contextStackList
				selected: #contextStackIndex changeSelected: #debugAt:
				menu: nil keystroke: nil]
		ifTrue:
			[notifyPane _ PluggableTextMorph on: self text: nil accept: nil
				readSelection: nil menu: #debugProceedMenu:.
			notifyPane editString: (self preDebugNotifierContentsFrom: messageString);
				askBeforeDiscardingEdits: false].

	window addMorph: notifyPane frame: (0@contentTop corner: 1@1).
	"window deleteCloseBox.
		chickened out by commenting the above line out, sw 8/14/2000 12:54"
	window setBalloonTextForCloseBox.

	^ window openInWorldExtent: extentToUse