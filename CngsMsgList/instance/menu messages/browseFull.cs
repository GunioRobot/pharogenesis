browseFull
	self classAndSelectorDo:
		[:cl :sel |  BrowserView browseFullForClass: cl method: sel from: controller]