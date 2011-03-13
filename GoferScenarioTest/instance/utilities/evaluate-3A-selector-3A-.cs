evaluate: aClassSelector selector: aMethodSelector
	self assertClass: aClassSelector selector: aMethodSelector.
	^ (Smalltalk at: aClassSelector) new perform: aMethodSelector