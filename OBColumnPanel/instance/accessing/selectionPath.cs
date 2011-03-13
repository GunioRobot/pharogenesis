selectionPath
	^(self columns 
		collect: [:e | e parent] 
		thenSelect: [:e | e notNil]) allButFirst