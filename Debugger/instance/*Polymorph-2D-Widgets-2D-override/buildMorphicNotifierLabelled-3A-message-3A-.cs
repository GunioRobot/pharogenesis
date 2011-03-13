buildMorphicNotifierLabelled: label message: messageString
	| notifyPane window extentToUse row|
	self expandStack.
	window := (PreDebugWindow labelled: label) model: self.
	extentToUse := 450 @ 156. "nice and wide to show plenty of the error msg"
	window
		addMorph: (row := self buttonRowForPreDebugWindow: window)
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1@0) offsets: (0@0 corner: 0@row minExtent y)).
	row color: Color transparent.
	Preferences eToyFriendly | messageString notNil
		ifFalse:
			[notifyPane := PluggableListMorph on: self list: #contextStackList
				selected: #contextStackIndex changeSelected: #debugAt:
				menu: nil keystroke: nil]
		ifTrue:
			[notifyPane := PluggableTextMorph on: self text: nil accept: nil
				readSelection: nil menu: #debugProceedMenu:.
			notifyPane editString: (self preDebugNotifierContentsFrom: messageString);
				askBeforeDiscardingEdits: false].
	window
		addMorph: notifyPane
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1@1) offsets: (0@24 corner: 0@0)).
	window setBalloonTextForCloseBox.
	window openInWorldExtent: extentToUse.
	window currentWorld displayWorld. "helps with interrupt not working somehow."
	^window