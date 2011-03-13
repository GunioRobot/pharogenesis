openAsMorphOn: anObject withEvalPane: withEval
			withLabel: label valueViewClass: valueViewClass
	"Note: for now, this always adds an eval pane, and ignores the valueViewClass"
	| window inspector |
	inspector _ self inspect: anObject.
	window _ (SystemWindow labelled: anObject defaultLabelForInspector) model: inspector.

	window addMorph: (PluggableListMorph on: inspector list: #fieldList
				selected: #selectionIndex changeSelected: #toggleIndex: menu: #fieldListMenu:)
		frame: (0@0 corner: 0.3@0.7).
	window addMorph: (PluggableTextMorph on: inspector text: #contents accept: #accept:
				readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0.3@0 corner: 1@0.7).
	window addMorph: (PluggableTextMorph on: inspector text: #trash accept: #trash:
				readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@0.7 corner: 1@1).

	window openInWorld