buildErrorsList
	^PluggableListMorph
				on: self
				list: #errorsList
				selected: #selectedErrorTest
				changeSelected: #debugErrorTest:.
