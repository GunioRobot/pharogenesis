browse
	controller controlTerminate.
	self classAndSelectorDo:
		[:cl :sel |  
			BrowserView openMessageBrowserForClass: cl selector: sel editString: nil].
	controller controlInitialize