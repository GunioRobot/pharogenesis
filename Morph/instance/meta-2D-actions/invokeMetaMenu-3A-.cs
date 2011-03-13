invokeMetaMenu: evt
	| menu |
	menu _ self buildMetaMenu: evt.
	menu addTitle: self externalName.
	menu popUpEvent: evt in: self world