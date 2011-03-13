initPinSpecs 
	pinSpecs _ Array
		with: (PinSpec new pinName: 'list' direction: #input
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: getListSelector modelWriteSelector: nil
				defaultValue: #(one two three) pinLoc: 1.5)
		with: (PinSpec new pinName: 'index' direction: #inputOutput
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: getIndexSelector modelWriteSelector: setIndexSelector
				defaultValue: 0 pinLoc: 2.5)
		with: (PinSpec new pinName: 'selectedItem' direction: #output
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: nil modelWriteSelector: setSelectionSelector
				defaultValue: nil pinLoc: 3.5)