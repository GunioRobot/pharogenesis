buildMorphicFilterListFor: model
	^PluggableListMorph
		on: model 
		list: #activeFilterDescriptions  
		selected: #selectedActiveFilterIndex  
		changeSelected: #selectedActiveFilterIndex: 
		menu: #filterBrowserMenu:.