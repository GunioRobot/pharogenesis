colorConvertMCU

	^ currentComponents size = 3
		ifTrue:
			[self useFloatingPoint
				ifTrue: [self colorConvertFloatYCbCrMCU]
				ifFalse: [self colorConvertIntYCbCrMCU]]
		ifFalse: [self colorConvertGrayscaleMCU]