processButtonRecords: id from: data cxForm: haveCxForm
	| flags state characterId layer matrix cxForm |
	[flags := data nextByte.
	flags = 0] whileFalse:[
		state := flags bitAnd: 15.
		characterId := data nextWord.
		layer := data nextWord.
		matrix := data nextMatrix.
		haveCxForm ifTrue:[cxForm := data nextColorMatrix: version >= 3].
		self recordButton: id 
			character: characterId 
			state: state 
			layer: layer 
			matrix: matrix
			colorTransform: cxForm].