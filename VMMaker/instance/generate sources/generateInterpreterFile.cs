generateInterpreterFile
	"Translate the Smalltalk description of the virtual machine into C. If 'self doInlining' is true, small method bodies are inlined to reduce procedure call overhead. On the PPC, this results in a factor of three speedup with only 30% increase in code size. "
"Subclasses can use specialised versions of CCodeGenerator and interpreterClass"

	|  cg |
	self needsToRegenerateInterpreterFile ifFalse:[^nil].

	self interpreterClass initialize.
	ObjectMemory initialize.
	cg _ self createCodeGenerator.
	cg addClass: self interpreterClass.
	cg addClass: ObjectMemory.

	cg storeCodeOnFile: self interpreterFilePath doInlining: self doInlining