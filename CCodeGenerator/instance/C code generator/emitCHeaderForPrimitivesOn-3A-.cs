emitCHeaderForPrimitivesOn: aStream
	"Write a C file header for compiled primitives onto the given stream."

	aStream nextPutAll: '/* Automatically generated from Squeak on '.
	aStream nextPutAll: Time dateAndTimeNow printString.
	aStream nextPutAll: ' */'; cr; cr.

	aStream nextPutAll: '#include "sq.h"'; cr; cr.

	aStream nextPutAll: '
/* Memory Access Macros */
#define byteAt(i) (*((unsigned char *) (i)))
#define byteAtput(i, val) (*((unsigned char *) (i)) = val)
#define longAt(i) (*((int *) (i)))
#define longAtput(i, val) (*((int *) (i)) = val)

/*** Imported Functions/Variables ***/
extern int stackValue(int);
extern int successFlag;
'.
	aStream cr.