activeTab
	activeTab ifNil: [
		self tabs size > 0 ifTrue: [
			activeTab _ self tabs first key.
			activeTab active: true]].
	^ activeTab 