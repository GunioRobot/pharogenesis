buildFailuresList
	^PluggableListMorph
				on: self
				list: #failuresList
				selected: #selectedFailureTest
				changeSelected: #debugFailureTest:.
