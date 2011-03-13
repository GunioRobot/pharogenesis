panels
	^ {self navigationPanel. self optionalButtonPanel. self definitionPanel} 
		reject: [:ea | ea isNil]