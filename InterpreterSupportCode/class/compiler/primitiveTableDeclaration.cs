primitiveTableDeclaration
	"InterpreterSupportCode primitiveTableDeclaration"

	| primitives internal external declared |
	primitives _ Interpreter initialize; primitiveTable.
	internal _ #(
		primitiveBlockCopy primitiveDoPrimitiveWithArgs
		primitivePerform primitivePerformWithArgs
		primitiveValue primitiveValueWithArgs).
	external _ Interpreter primitiveTable reject: [:prim | internal includes: prim].
	declared _ IdentitySet new.
	^String streamContents: [:str |
	str	nextPutAll:	'// generated automatically at ';
		print:		Time now;
		nextPutAll:	' on ';
		print:		Date today;
		cr;
		nextPutAll:	'// DO NOT EDIT!!!';
		cr; cr;
		nextPutAll:	'#define MaxPrimitiveIndex ';
		print:		primitives size - 1;
		cr; cr.
	internal do: [:prim |
		str	nextPutAll: 'extern void ';
			nextPutAll: prim;
			nextPutAll: '(void);'; cr].
	str	cr;
		nextPutAll:	'extern "C" {'; cr;
		nextPutAll:	'  void primitiveFail(void);'; cr.
	external do: [:prim |
	(declared includes: prim)
		ifFalse: [str	nextPutAll: '  void ';
					nextPutAll:	prim;
					nextPutAll: '(void);'; cr].
	declared add: prim].
	str	nextPutAll:	'};'; cr.
	]