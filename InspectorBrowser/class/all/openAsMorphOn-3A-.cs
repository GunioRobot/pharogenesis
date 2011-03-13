openAsMorphOn: anObject
	"(InspectorBrowser openAsMorphOn: SystemOrganization) openInMVC"
	| window inspector |
	inspector _ self inspect: anObject.
	window _ (SystemWindow labelled: anObject defaultLabelForInspector)
				model: inspector.

	window addMorph: (PluggableListMorph on: inspector list: #fieldList
				selected: #selectionIndex changeSelected: #toggleIndex: menu: #fieldListMenu:)
		frame: (0@0 corner: 0.3@0.5).
	window addMorph: (PluggableTextMorph on: inspector text: #contents accept: #accept:
				readSelection: nil menu: #codePaneMenu:shifted:)
		frame: (0.3@0 corner: 1.0@0.5).
	window addMorph: (PluggableListMorph on: inspector list: #msgList
				selected: #msgListIndex changeSelected: #msgListIndex: menu: #msgListMenu:)
		frame: (0@0.5 corner: 0.3@1.0).
	window addMorph: (PluggableTextMorph on: inspector text: #msgText accept: #msgAccept:from:
				readSelection: nil menu: #msgPaneMenu:shifted:)
		frame: (0.3@0.5 corner: 1.0@1.0).
	
	window position: 16@0.  "Room for scroll bar."
	^ window