writeWords: obj

	self new: obj
		class: obj class
		length: (self sizeInWordsOf: obj)
		trace: []
		write: [1 to: obj basicSize do: [:i | self write4Bytes: (obj instVarAt: i)]]