openAsMorphOn: anObject withLabel: aLabel
	"(Inspector openAsMorphOn: SystemOrganization) openInMVC"
	| window inspector |
	inspector _ self inspect: anObject.
	window _ (SystemWindow labelled: aLabel) model: inspector.
	window addMorph: (
		PluggableListMorph new
			doubleClickSelector: #inspectSelection;

			on: inspector list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:)
		frame: (0@0 corner: self horizontalDividerProportion @ self verticalDividerProportion).
	window addMorph: (PluggableTextMorph on: inspector text: #contents accept: #accept:
				readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (self horizontalDividerProportion @0 corner: 1@self verticalDividerProportion).
	window addMorph: ((PluggableTextMorph on: inspector text: #trash accept: #trash:
				readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
					askBeforeDiscardingEdits: false)
		frame: (0@self verticalDividerProportion corner: 1@1).
	window setUpdatablePanesFrom: #(fieldList).
	window position: 16@0.  "Room for scroll bar."
	^ window