buildMorphicTocEntryListFor: model 
	| listFont |
	listFont := (TextStyle named: #DefaultFixedTextStyle) defaultFont.
	^ (PluggableMultiColumnListMorph
				on: model
				list: nil
				selected: #tocIndex
				changeSelected: #setTOCIndex:
				menu: #tocMenu:
				keystroke: #tocKeystroke:)
		font: listFont;
		getListSizeSelector: #tocSize;
		getListElementSelector: #tocColumnsForRow: ;
		getListSelector: #tocEntryList ;
		enableDragNDrop: false;
		yourself