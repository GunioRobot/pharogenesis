writeFramesFrom: mpegFile on: aBinaryStream quality: quality
	"Write the frames of the given MPEG movie on the given stream at the given JPEG quality level. Answer a collection of frame offsets. The size of this collection is one larger than the number of frames; it's final entry is the stream position just after the final frame. The byte count for any frame can thus be computed as the difference between two adjacent offsets."

	| frameCount frameOffsets frameForm |
	mpegFile hasVideo ifFalse: [^ Array with: aBinaryStream position].
	frameCount _ mpegFile videoFrames: 0.
	frameOffsets _ OrderedCollection new: frameCount + 1.
	frameForm _ Form
		extent: (mpegFile videoFrameWidth: 0)@(mpegFile videoFrameHeight: 0)
		depth: 32.

	[(mpegFile videoGetFrame: 0) < (mpegFile videoFrames: 0)] whileTrue: [
		frameOffsets addLast: aBinaryStream position.
		mpegFile videoReadFrameInto: frameForm stream: 0.
		self writeFrame: frameForm on: aBinaryStream quality: quality displayFlag: true].

	frameOffsets addLast: aBinaryStream position.  "add final offset"
	^ frameOffsets
