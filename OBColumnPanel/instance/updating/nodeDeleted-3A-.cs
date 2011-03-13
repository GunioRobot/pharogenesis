nodeDeleted: ann
	ann node = self root 
		ifTrue: 
			[self columns first clear.
			self announcer announce: (OBSelectionChanged column: self)]