popRemappableOop
	"Pop and return the possibly remapped object from the remap buffer."

	| oop |
	oop _ remapBuffer at: remapBufferCount.
	remapBufferCount _ remapBufferCount - 1.
	^ oop