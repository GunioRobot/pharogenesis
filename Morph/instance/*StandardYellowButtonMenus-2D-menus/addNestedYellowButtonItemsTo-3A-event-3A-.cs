addNestedYellowButtonItemsTo: aMenu event: evt
	"Add items to aMenu starting with me and proceeding down through my submorph chain,
	letting any submorphs that include the event position contribute their items to the bottom of the menu, separated by a line."

	self addYellowButtonMenuItemsTo: aMenu event: evt.
	(self
		submorphThat: [:m | m containsPoint: evt position]
		ifNone: [])
		ifNotNilDo: [:m | | submenu |
			(m addMyYellowButtonMenuItemsToSubmorphMenus
					and: [m hasYellowButtonMenu])
				ifTrue: [aMenu addLine.
					submenu := MenuMorph new defaultTarget: m.
					m addNestedYellowButtonItemsTo: submenu event: evt.
					aMenu add: m externalName subMenu: submenu]]