initialize
	outputStream := WriteStream on: (String new: self initialBufferSize).
	lastMatchWasEmpty := true