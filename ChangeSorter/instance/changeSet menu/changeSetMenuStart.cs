changeSetMenuStart

	| menu |
	menu _ self changeSetMenu: CustomMenu new.
	menu ifNotNil: [menu invokeOn: self].
