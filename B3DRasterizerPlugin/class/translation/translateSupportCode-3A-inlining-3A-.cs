translateSupportCode: cSrc inlining: inlineFlag
	"Inline the given C support code if inlineFlag is set.
	Inlining converts any functions of the form:
		/* INLINE someFunction(args) */
		void someFunction(declaration args)
		{
			... actual code ...
		}
		/* --INLINE-- */
	into 
		#define someFunction(args) \
		/* void someFunction(declaration args) */ \
		{ \
			... actual code ... \
		} \
		/* --INLINE-- */
	thus using a hard way of forcing inlining by the C compiler."
	| in out postfix line |
	true ifTrue:[^cSrc]. "Disabled until I had time to actually test it ;-)"
	inlineFlag ifFalse:[^cSrc].
	in _ ReadStream on: cSrc.
	out _ WriteStream on: (String new: cSrc size).
	postfix _ ''.
	[in atEnd] whileFalse:[
		line _ in upTo: Character cr.
		(line includesSubString:' INLINE ') ifTrue:[
			"New inline start"
			postfix _ ' \'.
			line _ line copyFrom: (line findString: 'INLINE')+6 to: line size.
			line _ line copyFrom: 1 to: (line findString: '*/')-1.
			out nextPutAll:'#define'; nextPutAll: line; nextPutAll: postfix; cr.
			"Next line has function declaration -- comment this out"
			[line _ in upTo: Character cr.
			line includes: ${] whileFalse:[
				out nextPutAll:'/* '; nextPutAll: line; nextPutAll:' */'; nextPutAll: postfix; cr.
			].
			(line first = ${) ifTrue:[
				out nextPutAll: line; nextPutAll: postfix; cr.
			] ifFalse:[
				out nextPutAll: '/* '; 
					nextPutAll:(line copyFrom: 1 to: (line findString:'{')-1);
					nextPutAll:' */';
					nextPutAll:(line copyFrom: (line findString:'{') to: line size);
					nextPutAll: postfix;
					cr.
			].
		] ifFalse:[
			(line includesSubString:'--INLINE--') ifTrue:[postfix _ ''].
			out nextPutAll: line; nextPutAll: postfix; cr.
		].
	].
	^out contents.
	"| fs |
	fs _ FileStream newFileNamed:'b3dr.c'.
	fs nextPutAll: (B3DRasterizerPlugin translateSupportCode: B3DRasterizerPlugin b3dRemapC inlining: true).
	fs close."
