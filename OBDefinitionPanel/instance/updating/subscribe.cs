subscribe
	self announcer 
		observe: OBAboutToChange
		send: #aboutToChange:
		to: self;
		
		observe: OBSelectionChanged
		send: #selectionChanged:
		to: self;
		
		observe: OBRefreshRequired
		send: #refresh:
		to: self;
				
		observe: OBDefinitionChanged
		send: #definitionChanged: 
		to: self.