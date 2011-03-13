openFullMorphicLabel: labelString
	| window |
	self expandStack.
	window _ (SystemWindow labelled: labelString) model: self.

	window addMorph: (PluggableListMorph on: self list: #contextStackList
			selected: #contextStackIndex changeSelected: #toggleContextStackIndex:
			menu: #contextStackMenu:shifted: keystroke: #contextStackKey:from:)
		frame: (0@0 corner: 1@0.3).
	window addMorph: (PluggableTextMorph on: self
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@0.3 corner: 1@0.7).
	window addMorph: (PluggableListMorph on: self receiverInspector list: #fieldList
			selected: #selectionIndex changeSelected: #toggleIndex:
			menu: #fieldListMenu: keystroke: #inspectorKey:from:)
		frame: (0@0.7 corner: 0.2@1).
	window addMorph: (PluggableTextMorph on: self receiverInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.2@0.7 corner: 0.5@1).
	window addMorph: (PluggableListMorph on: self contextVariablesInspector list: #fieldList
			selected: #selectionIndex changeSelected: #toggleIndex:
			menu: #fieldListMenu: keystroke: #inspectorKey:from:)
		frame: (0.5@0.7 corner: 0.7@1).
	window addMorph: (PluggableTextMorph on: self contextVariablesInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.7@0.7 corner: 1@1).

	^ window openInWorld
