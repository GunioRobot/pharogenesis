testEmbeddingFlags
	"HostFont basicNew testEmbeddingFlags"
	| list fontHandle |
	list _ self class listFontNames.
	list do:[:fName|
		fontHandle _ self primitiveCreateFont: fName size: 12 emphasis: 0.
		fontHandle ifNotNil:[
			type _ self primitiveFontEmbeddingFlags: fontHandle.
			Transcript cr; show: fName,': ', type printString.
			self primitiveDestroyFont: fontHandle.
		].
	].