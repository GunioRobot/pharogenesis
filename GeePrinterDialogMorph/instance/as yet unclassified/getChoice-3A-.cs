getChoice: aSymbol

	aSymbol == #landscapeFlag ifTrue: [^printSpecs landscapeFlag].
	aSymbol == #drawAsBitmapFlag ifTrue: [^printSpecs drawAsBitmapFlag].
