initPinSpecs 
	pinSpecs _ Array
		with: (PinSpec new pinName: 'value' direction: #inputOutput
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: getTextSelector modelWriteSelector: setTextSelector
				defaultValue: nil pinLoc: 1.5)