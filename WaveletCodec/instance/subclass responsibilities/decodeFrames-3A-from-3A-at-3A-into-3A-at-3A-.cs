decodeFrames: frameCount from: srcByteArray at: srcIndex into: dstSoundBuffer at: dstIndex
	"Decode the given number of monophonic frames starting at the given index in the given ByteArray of compressed sound data and storing the decoded samples into the given SoundBuffer starting at the given destination index. Answer a pair containing the number of bytes of compressed data consumed and the number of decompressed samples produced."
	"Note: Assume that the sender has ensured that the given number of frames will not exhaust either the source or destination buffers."

	| frameBase coeffArray scale i c nullCount samples sourceFrameEnd frameSize inStream val |
	inStream _ ReadStream on: srcByteArray from: srcIndex to: srcByteArray size.
	"frameCount _ " inStream nextNumber: 4.
	samplesPerFrame _ inStream nextNumber: 4.
	nLevels _ inStream nextNumber: 4.
	alpha _ Float fromIEEE32Bit: (inStream nextNumber: 4).
	beta _ Float fromIEEE32Bit: (inStream nextNumber: 4).
	fwt ifNil:
		["NOTE: This should read parameters from the encoded data"
		fwt _ FWT new.
		fwt nSamples: samplesPerFrame nLevels: nLevels.
		fwt setAlpha: alpha beta: beta].
	frameBase _ dstIndex.
	coeffArray _ fwt coeffs.  "A copy that we can modify"

	1 to: frameCount do:
		[:frame | 

		"Decode the scale for this frame"
		frameSize _ inStream nextNumber: 2.
		sourceFrameEnd _ frameSize + inStream position.
		scale _ Float fromIEEE32Bit: (inStream nextNumber: 4).

		"Expand run-coded samples to scaled float values."
		i _ 5.
		[i <= coeffArray size]
			whileTrue:
			[c _ inStream next.
			c < 128
				ifTrue: [nullCount _ c < 112
							ifTrue: [c + 1]
							ifFalse: [(c-112)*256 + inStream next + 1].
						i to: i + nullCount - 1 do: [:j | coeffArray at: j put: 0.0].
						i _ i + nullCount]
				ifFalse: [val _ (c*256 + inStream next) - 32768 - 16384.
						coeffArray at: i put: val * scale.
						i _ i + 1]].

		"Copy float values into the wavelet sample array"		
			fwt coeffs: coeffArray.

		"Compute the transform"
		fwt transformForward: false.

		"Determine the scale for this frame"
		samples _ fwt samples.
		samples size = samplesPerFrame ifFalse: [self error: 'frame size error'].
		1 to: samples size do:
			[:j | dstSoundBuffer at: frameBase + j - 1 put: (samples at: j) asInteger].

		inStream position = sourceFrameEnd ifFalse: [self error: 'frame size error'].
		frameBase _ frameBase + samplesPerFrame].

	^ Array with: inStream position + 1 - srcIndex
			with: frameBase - dstIndex