squeakPlatSpecFile

	^ '/* sqPlatformSpecific.h -- Platform-specific prototypes and definitions */

/* How to use this file:
   This file is for general platform-specific macros and declarations.
   Function prototypes that are unlikely to introduce name conflicts on
   other platforms can be added directly. Macro re-definitions or conflicting
   function prototypes can be wrapped in a #ifdefs. Alternatively, a customized
   version of this file can be used on that platform. The goal is to keep all
   the other header files generic across platforms. To override a definition or
   macro from sq.h, you must first #undef it, then provide the new definition.
*/

/* unix-specific prototypes */
void aioPollForIO(int microSeconds, int extraFd);

#ifdef macintosh
/* replace the image file manipulation macros with functions */
#undef sqImageFile
#undef sqImageFileClose
#undef sqImageFileOpen
#undef sqImageFilePosition
#undef sqImageFileRead
#undef sqImageFileSeek
#undef sqImageFileWrite

typedef int sqImageFile;
void        sqImageFileClose(sqImageFile f);
sqImageFile sqImageFileOpen(char *fileName, char *mode);
int         sqImageFilePosition(sqImageFile f);
int         sqImageFileRead(void *ptr, int elementSize, int count, sqImageFile f);
void        sqImageFileSeek(sqImageFile f, int pos);
int         sqImageFileWrite(void *ptr, int elementSize, int count, sqImageFile f);

#endif /* macintosh */


#ifdef ACORN
/* acorn memory allocation */
#undef sqAllocateMemory
#define sqAllocateMemory(bytes) platAllocateMemory(bytes)
#undef sqFilenameFromString
#define sqFilenameFromString(dst, src, num) sqFilenameFromString(dst, src, num) 

#ifdef LITTLE_ENDIAN
#define ifLittleEndianDoelseDo(a, b) a
#else
#define ifLittleEndianDoelseDo(a, b) b
#endif

#endif /* ACORN */
'.
