pushRemappableOop: oop
	"Record the given object in a the remap buffer. Objects in this buffer are remapped when a compaction occurs. This facility is used by the interpreter to ensure that objects in temporary variables are properly remapped."

	remapBuffer at: (remapBufferCount _ remapBufferCount + 1) put: oop.