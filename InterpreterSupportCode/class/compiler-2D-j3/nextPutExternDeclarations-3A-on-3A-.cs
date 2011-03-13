nextPutExternDeclarations: tricky on: file
	file nextPutAll: 'static const unsigned ArgumentCountBit=	0x01; // prim reads argumentCount'; cr.
	file nextPutAll: 'static const unsigned StackPointerBit=	0x02; // prim reads stackPointer'; cr.
	file nextPutAll: 'static const unsigned SuccessFlagBit=	0x04; // prim writes successFlag'; cr.
	file nextPutAll: 'static const unsigned ActiveFrameBit=	0x08; // prim may cause GC'; cr.
	file nextPutAll: 'static const unsigned IntrinsicPrimBit=	0x10; // prim not exported to j3'; cr.
	file nextPutAll: 'static const unsigned PrimitiveFailBit=	0x20; // prim has no primitive response'; cr.
	file cr.
	file nextPutAll: 'typedef int (*primitive_t)(void);'; cr; cr.
	file nextPutAll: 'extern primitive_t primitiveTable[];'; cr; cr.
	file nextPutAll: 'extern unsigned char primitiveFlags[];'; cr; cr.
	file nextPutAll: '// primitives imported from the Interpreter'; cr; cr.
	file nextPutAll: 'extern "C" {'; cr.
	tricky keysDo: [:prim | file nextPutAll: '  int '; nextPutAll: prim; nextPutAll: '(void);'; cr].
	file nextPutAll: '};'; cr; cr.