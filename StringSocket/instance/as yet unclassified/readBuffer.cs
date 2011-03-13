readBuffer

	^ readBuffer ifNil: [readBuffer _ String new: 20000].
