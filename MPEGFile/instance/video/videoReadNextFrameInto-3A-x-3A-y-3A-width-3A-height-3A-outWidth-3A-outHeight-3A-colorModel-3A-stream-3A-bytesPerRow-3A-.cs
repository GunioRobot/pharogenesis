videoReadNextFrameInto: aFormBuffer x: x y: y width: width height: height outWidth: aTargetWidth outHeight: aTargetHeight colorModel: colorModel stream: aStream bytesPerRow: aByteCount
	"return nonZero if failure "

	self hasVideo ifFalse: [^-1].
	^[self primVideoReadNextFrameFor: self fileHandle into: aFormBuffer x: x y: y width: width height: height outWidth: aTargetWidth outHeight: aTargetHeight colorModel: colorModel stream: aStream bytesPerRow: aByteCount] on: Error do: [-1]

"/* Supported color models for mpeg3_read_frame */
#define MPEG3_RGB565 2
#define MPEG3_RGB555 14  //JMM for mac
#define MPEG3_RGBI555 16  //SVP for intel
#define MPEG3_BGR888 0
#define MPEG3_BGRA8888 1
#define MPEG3_RGB888 3
#define MPEG3_RGBA8888 4  
#define MPEG3_ARGB8888 13  //JMM for mac
#define MPEG3_RGBA16161616 5

/* Color models for the 601 to RGB conversion */
/* 601 not implemented for scalar code */
#define MPEG3_601_RGB565 11
#define MPEG3_601_RGB555 15 //JMM for Squeak
#define MPEG3_601_RGBI555 17 //SVP for intel
#define MPEG3_601_BGR888 7
#define MPEG3_601_BGRA8888 8
#define MPEG3_601_RGB888 9
#define MPEG3_601_RGBA8888 10
#define MPEG3_601_ARGB8888 12 //JMM for Squeak
"