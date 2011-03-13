listMorph
	^ (PluggableListMorph
		on: self
		list: #list
		selected: #selection
		changeSelected: #selection:
		menu: #menu:
		keystroke: #keystroke:from:)
			getListElementSelector: #listAt:;
			getListSizeSelector: #listSize;
			dragEnabled: self dragEnabled;
			dropEnabled: self dropEnabled;
			borderWidth: 0;
			autoDeselect: false;
			adoptPaneColor: panel defaultBackgroundColor;
			yourself