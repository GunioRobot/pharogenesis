toggleStatus
	openForEditing _ openForEditing not.
	openForEditing
		ifTrue:
			[self openEditing.
			menuButton state: #off.
			menuButton setBalloonText: 'resume being a parts bin']
		ifFalse:
			[self closeEditing.
			menuButton state: #on.
			menuButton setBalloonText: 'open for editing']