initPinSpecs 
	pinSpecs _ Array
		with: (PinSpec new pinName: 'text' direction: #inputOutput
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: getTextSelector modelWriteSelector: setTextSelector
				defaultValue: 'some text' pinLoc: 1.5)