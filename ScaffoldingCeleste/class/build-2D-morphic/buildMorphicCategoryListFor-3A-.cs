buildMorphicCategoryListFor: model
	^(PluggableListMorphByItem
				on: model
				list: #categoryList
				selected: #category
				changeSelected: #setCategory:
				menu: #categoryMenu:
				keystroke: #categoriesKeystroke:) enableDragNDrop: true.
