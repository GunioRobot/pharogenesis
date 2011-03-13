testEmbeddingFlags
	"HostFont basicNew testEmbeddingFlags"
	| list fontHandle |
	list := self class listFontNames.
	list do: 
		[ :fName | 
		fontHandle := self 
			primitiveCreateFont: fName
			size: 12
			emphasis: 0.
		fontHandle ifNotNil: 
			[ type := self primitiveFontEmbeddingFlags: fontHandle.
			Transcript
				cr;
				show: fName , ': ' , type printString.
			self primitiveDestroyFont: fontHandle ] ]