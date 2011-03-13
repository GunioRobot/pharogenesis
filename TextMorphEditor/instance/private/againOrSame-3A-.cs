againOrSame: bool 

	super againOrSame: bool.
	(morph respondsTo: #editView) 
		ifTrue: [morph editView selectionInterval: self selectionInterval]