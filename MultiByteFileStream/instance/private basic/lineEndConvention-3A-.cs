lineEndConvention: aSymbol

	(lineEndConvention := aSymbol) ifNotNil: [ self wantsLineEndConversion: true ]