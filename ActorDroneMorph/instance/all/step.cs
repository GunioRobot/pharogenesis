step

	running ifTrue: [
		self world model perform: self onTicksSelector with: self].
