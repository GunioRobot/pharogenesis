buildMorphicTocEntryListFor: model 
	^ PluggableMultiColumnListMorphByItem
				on: model
				list: #tocEntryList
				selected: #tocEntry
				changeSelected: #setTOCEntry:
				menu: #tocMenu:
				keystroke: #tocKeystroke: