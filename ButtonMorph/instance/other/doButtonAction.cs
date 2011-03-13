doButtonAction

	self nameInModel ~~ nil ifTrue: [
		self world model perform: self buttonUpSelector].
