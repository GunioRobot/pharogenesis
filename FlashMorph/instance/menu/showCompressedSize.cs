showCompressedSize
	| size string |
	size := self originalFileSize.
	string := size = 0 
		ifTrue: ['Compressed size: not available']
		ifFalse: ['Compressed size: ' , size asStringWithCommas , ' bytes'].
	self world primaryHand attachMorph: ((TextMorph new)
				contents: string;
				beAllFont: ScriptingSystem fontForTiles)