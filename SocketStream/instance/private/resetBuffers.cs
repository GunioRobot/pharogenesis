resetBuffers
	"Recreate the buffers with default start sizes."

	inBuffer _ self streamBuffer: bufferSize.
	lastRead _ 0.
	inNextToWrite _ 1.
	outBuffer _ self streamBuffer: bufferSize.
	outNextToWrite _ 1