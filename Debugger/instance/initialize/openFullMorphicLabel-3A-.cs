openFullMorphicLabel: labelString
	| window aListMorph codeTop aTextMorph |
	self expandStack.
	window _ (SystemWindow labelled: labelString) model: self.
	aListMorph _ PluggableListMorph on: self list: #contextStackList
			selected: #contextStackIndex changeSelected: #toggleContextStackIndex:
			menu: #contextStackMenu:shifted: keystroke: #contextStackKey:from:.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph
		frame: (0@0 corner: 1@0.3).

	Preferences useAnnotationPanes
		ifFalse:
			[codeTop _ 0.3]
		ifTrue:
			[aTextMorph _ PluggableTextMorph on: self
					text: #annotation accept: nil
					readSelection: nil menu: nil.
			aTextMorph askBeforeDiscardingEdits: false.
			window addMorph: aTextMorph
				frame: (0@0.3 corner: 1@0.35).
			codeTop _ 0.35].

	Preferences optionalButtons ifTrue:
		[window addMorph: self optionalButtonRow frame: ((0@codeTop corner: 1 @ (codeTop + 0.1))).
		codeTop _ codeTop + 0.1].
	window addMorph: (PluggableTextMorph on: self
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0 @ codeTop corner: 1 @ 0.7).
	window addMorph: ((PluggableListMorph on: self receiverInspector list: #fieldList
			selected: #selectionIndex changeSelected: #toggleIndex:
			menu: #fieldListMenu: keystroke: #inspectorKey:from:) doubleClickSelector: #inspectSelection)
		frame: (0@0.7 corner: 0.2@1).
	window addMorph: (PluggableTextMorph on: self receiverInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.2@0.7 corner: 0.5@1).
	window addMorph: ((PluggableListMorph on: self contextVariablesInspector list: #fieldList
			selected: #selectionIndex changeSelected: #toggleIndex:
			menu: #fieldListMenu: keystroke: #inspectorKey:from:) doubleClickSelector: #inspectSelection)
		frame: (0.5@0.7 corner: 0.7@1).
	window addMorph: (PluggableTextMorph on: self contextVariablesInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.7@0.7 corner: 1@1).

	^ window openInWorld