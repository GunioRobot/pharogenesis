noiseStringMorph: aNoiseString

	| sMorph |

	sMorph _ self aSimpleStringMorphWith: aNoiseString.
	sMorph 
		font: (self fontToUseForSpecialWord: aNoiseString); 
		setProperty: #noiseWord toValue: true.

	^sMorph
