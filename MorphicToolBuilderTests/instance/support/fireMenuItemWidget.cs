fireMenuItemWidget
	(widget itemWithWording: 'Menu Item')
		ifNotNil: [:item | item doButtonAction]