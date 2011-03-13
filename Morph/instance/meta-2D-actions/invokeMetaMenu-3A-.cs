invokeMetaMenu: evt
	| menu |
	menu _ self buildMetaMenu: evt.
	menu addTitle: self externalName.
	self world ifNotNil: [
		menu popUpEvent: evt in: self world
	]