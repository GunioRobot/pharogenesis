initPanes
	self addMorph: (fieldPane _ ListPane new model: self slotName: 'fieldPane').
	self addMorph: (valuePane _ ScrollPane new model: self slotName: 'valuePane').
	self addMorph: (doitPane _ ScrollPane new model: self slotName: 'doitPane').