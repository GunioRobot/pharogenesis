showCompressedSize
	| size string |
	size _ self originalFileSize.
	size = 0 
		ifTrue:[string _ 'Compressed size: not available']
		ifFalse:[string _ 'Compressed size: ', size asStringWithCommas, ' bytes'].
	self world primaryHand attachMorph:
		(TextMorph new contents: string; beAllFont: ScriptingSystem fontForTiles).