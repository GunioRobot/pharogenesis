emitCHeaderOn: aStream
	"Write a C file header onto the given stream."

	aStream nextPutAll: '/* Automatically generated from Squeak on '.
	aStream nextPutAll: Time dateAndTimeNow printString.
	aStream nextPutAll: ' */'; cr; cr.
	self emitGlobalStructFlagOn: aStream.
	aStream nextPutAll: '#include "sq.h"'; cr.

	"Additional header files"
	headerFiles do:[:hdr|
		aStream nextPutAll:'#include '; nextPutAll: hdr; cr].

	aStream nextPutAll: '
/* memory access macros */
#define byteAt(i) (*((unsigned char *) (i)))
#define byteAtput(i, val) (*((unsigned char *) (i)) = val)
#define longAt(i) (*((int *) (i)))
#define longAtput(i, val) (*((int *) (i)) = val)

int printCallStack(void);
void error(char *s);
void error(char *s) {
	/* Print an error message and exit. */
	static int printingStack = false;

	printf("\n%s\n\n", s);
	if (!printingStack) {
		/* flag prevents recursive error when trying to print a broken stack */
		printingStack = true;
		printCallStack();
	}
	exit(-1);
}
'.
	aStream cr.