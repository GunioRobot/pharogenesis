processButtonRecords: id from: data cxForm: haveCxForm
	| flags state characterId layer matrix cxForm |
	[flags _ data nextByte.
	flags = 0] whileFalse:[
		state _ flags bitAnd: 15.
		characterId _ data nextWord.
		layer _ data nextWord.
		matrix _ data nextMatrix.
		haveCxForm ifTrue:[cxForm _ data nextColorMatrix: version >= 3].
		self recordButton: id 
			character: characterId 
			state: state 
			layer: layer 
			matrix: matrix
			colorTransform: cxForm].