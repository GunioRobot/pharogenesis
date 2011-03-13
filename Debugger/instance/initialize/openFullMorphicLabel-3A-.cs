openFullMorphicLabel: labelString
	| window aListMorph oldContextStackIndex |

	oldContextStackIndex _ contextStackIndex.
	self expandStack. "Sets contextStackIndex to zero."

	window _ (SystemWindow labelled: labelString) model: self.
	aListMorph _ PluggableListMorph on: self list: #contextStackList
			selected: #contextStackIndex changeSelected: #toggleContextStackIndex:
			menu: #contextStackMenu:shifted: keystroke: #contextStackKey:from:.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph
		frame: (0@0 corner: 1@0.3).

	self addLowerPanesTo: window at: (0@0.3 corner: 1@0.7) with: nil.

	window addMorph: (
		PluggableListMorph new
			doubleClickSelector: #inspectSelection;

			on: self receiverInspector list: #fieldList
			selected: #selectionIndex changeSelected: #toggleIndex:
			menu: #fieldListMenu: keystroke: #inspectorKey:from:)
		frame: (0@0.7 corner: 0.2@1).
	window addMorph: (PluggableTextMorph on: self receiverInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.2@0.7 corner: 0.5@1).
	window addMorph: (
		PluggableListMorph new
			doubleClickSelector: #inspectSelection;

			on: self contextVariablesInspector list: #fieldList
			selected: #selectionIndex changeSelected: #toggleIndex:
			menu: #fieldListMenu: keystroke: #inspectorKey:from:)
		frame: (0.5@0.7 corner: 0.7@1).
	window addMorph: (PluggableTextMorph on: self contextVariablesInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.7@0.7 corner: 1@1).
	window openInWorld.
	self toggleContextStackIndex: oldContextStackIndex.
	^ window 