replayPreferences: preferences 
	| s v |
	s _ SortedCollection new
				sortBlock: [:a :b | a last < b last].
	s addAll: preferences;
		 reSort.
	s
		do: [:e | 
			v _ self valueOfPreference: e first ifAbsent: ''.
			self setPreference: e first toValue: (v
					ifEmpty: ['']
					ifNotEmpty: [v , ' '])
					, e second]