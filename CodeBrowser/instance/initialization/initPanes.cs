initPanes
	self addMorph: (systemPane _ ListPane new model: self slotName: 'systemPane').
	self addMorph: (classPane _ ListPane new model: self slotName: 'classPane').
	self addMorph: (instButton _ SimpleButtonMorph new borderWidth: 2; color: paneColor;
							label: 'inst'; actionSelector: #instanceMode; target: self).
	self addMorph: (classButton _ SimpleButtonMorph new borderWidth: 2; color: paneColor;
							label: 'class'; actionSelector: #classMode; target: self).
	self addMorph: (categoryPane _ ListPane new model: self slotName: 'categoryPane').
	self addMorph: (messagePane _ ListPane new model: self slotName: 'messagePane').
	self addMorph: (codePane _ ScrollPane new model: self slotName: 'codePane').