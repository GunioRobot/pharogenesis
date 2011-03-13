pageFormForFrame: frameNo

	| f form oldFrame |
oldFrame _ frameNumber.
self goToPage: frameNo.
form _ currentPage image deepCopy.
self goToPage: oldFrame.
true ifTrue: [^ form].

	f _ FileStream readOnlyFileNamed: movieFileName.
	form _ Form extent: frameSize depth: frameDepth.

	"For some weird reason, the next line does not work..."
	f position: (self filePosForFrameNo: frameNo).
	"... but this line was found empirically to work instead."
	f position: (128 + ((frameNo-1)*(form bits size*4+4)) + 4).

	f nextInto: form bits.
	f close.
	^ form