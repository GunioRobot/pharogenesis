savedPreferences
	 ^ (self class organization listAtCategoryNamed: #'saved preferences')
			collect: [:e | self perform: e]