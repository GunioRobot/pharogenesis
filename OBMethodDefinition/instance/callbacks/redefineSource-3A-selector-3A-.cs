redefineSource: aText selector: newSelector
	newSelector = self selector 
		ifTrue: [source := aText]
		ifFalse: [(self methodNodeFor: newSelector) signalSelection].
