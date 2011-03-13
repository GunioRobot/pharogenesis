scan: inputStream 
	"Bind the input stream, fill the character buffers and first token buffer."

	source _ inputStream.
	self step.
	self step.
	self scanToken