initPinSpecs 
	pinSpecs _ Array
		with: (PinSpec new pinName: 'output' direction: #output
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: nil modelWriteSelector: nil
				defaultValue: nil pinLoc: 3.5)
		with: (PinSpec new pinName: 'a' direction: #input
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: nil modelWriteSelector: nil
				defaultValue: nil pinLoc: 1.5)
