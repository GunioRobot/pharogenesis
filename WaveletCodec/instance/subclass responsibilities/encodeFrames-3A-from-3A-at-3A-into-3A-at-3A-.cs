encodeFrames: frameCount from: srcSoundBuffer at: srcIndex into: dstByteArray at: dstIndex
	"Encode the given number of frames starting at the given index in the given monophonic SoundBuffer and storing the encoded sound data into the given ByteArray starting at the given destination index. Encode only as many complete frames as will fit into the destination. Answer a pair containing the number of samples consumed and the number of bytes of compressed data produced."
	"Note: Assume that the sender has ensured that the given number of frames will not exhaust either the source or destination buffers."

	| frameBase coeffs maxVal minVal c scale nullCount frameI outFrameSize threshold sm outStream cMin val |
	threshold _ 2000.
	fwt ifNil:
		[samplesPerFrame _ self samplesPerFrame.
		nLevels _ 8.
		"Here are some sample mother wavelets, with the compression achieved on a
		sample of my voice at a threshold of 2000:
									compression achieved "
		alpha _ 0.0.  beta _ 0.0.		"12.1"
		alpha _ 1.72.  beta _ 1.51.	"14.0"
		alpha _ -1.86.  beta _ -1.53.	"14.4"
		alpha _ 1.28.  beta _ -0.86.	"15.9"
		alpha _ -1.15.  beta _ 0.69.	"16.0"
		fwt _ FWT new.
		fwt nSamples: samplesPerFrame nLevels: nLevels.
		fwt setAlpha: alpha beta: beta].

	(outStream _ WriteStream on: dstByteArray from: dstIndex to: dstByteArray size)
		nextNumber: 4 put: frameCount;
		nextNumber: 4 put: samplesPerFrame;
		nextNumber: 4 put: nLevels;
		nextNumber: 4 put: alpha asIEEE32BitWord;
		nextNumber: 4 put: beta asIEEE32BitWord.
	frameBase _ srcIndex.
	1 to: frameCount do:
		[:frame | 

		"Copy float values into the wavelet sample array"		
		fwt samples: ((frameBase to: frameBase + samplesPerFrame-1) 
				collect: [:i | (srcSoundBuffer at: i) asFloat]).

		"Compute the transform"
		fwt transformForward: true.

		frameI _ outStream position+1.  "Reserve space for frame size"
		outStream nextNumber: 2 put: 0.

		"Determine and output the scale for this frame"
		coeffs _ fwt coeffs.
		maxVal _ 0.0.  minVal _ 0.0.
		5 to: coeffs size do:
			[:i | c _ coeffs at: i.
			c > maxVal ifTrue: [maxVal _ c].
			c < minVal ifTrue: [minVal _ c]].
		scale _ (maxVal max: minVal negated) / 16000.0.  "Will scale all to -16k..16k: 15 bits"
		outStream nextNumber: 4 put: scale asIEEE32BitWord.

		"Copy scaled values, with run-coded sequences of 0's, to destByteArray"
		nullCount _ 0.
		cMin _ threshold / scale.
		5 to: coeffs size do:
			[:i | c _ (coeffs at: i) / scale.
			c abs < cMin
			ifTrue: ["Below threshold -- count nulls."
					nullCount _ nullCount + 1]
			ifFalse: ["Above threshold -- emit prior null count and this sample."
					nullCount > 0 ifTrue:
						[nullCount <= 112
						ifTrue: [outStream nextNumber: 1 put: nullCount-1]
						ifFalse: [outStream nextNumber: 2 put: (112*256) + nullCount-1].
						nullCount _ 0].
						val _ c asInteger + 16384 + 32768.  "Map -16k..16k into 32k..64k"
						outStream nextNumber: 2 put: val]].

					nullCount > 0 ifTrue:
						[nullCount <= 112
						ifTrue: [outStream nextNumber: 1 put: nullCount-1]
						ifFalse: [outStream nextNumber: 2 put: (112*256) + nullCount-1]].
		outFrameSize _ outStream position+1 - frameI - 2.  "Write frame size back at the beginning"
		(WriteStream on: dstByteArray from: frameI to: dstByteArray size)
			nextNumber: 2 put: outFrameSize.
		frameBase _ frameBase + samplesPerFrame].

"This displays a temporary indication of compression achieved"
sm _ TextMorph new contents: (((frameBase - srcIndex) *2.0 / (outStream position+1 - dstIndex) truncateTo: 0.1) printString , ' : 1') asText allBold.
sm position: Sensor cursorPoint + (-20@30).
ActiveWorld addMorph: sm.
World doOneCycleNow.
sm delete.

	outStream position > dstByteArray size ifTrue:
		["The calling routine only provides buffer space for compression of 2:1 or better.  If you are just testing things, you can increase it to, eg, codeFrameSize _ frameSize*3, which would be sufficient for a threshold of 0 (lossless conversion)."
		self error: 'Buffer overrun'].

	^ Array with: frameBase - srcIndex
			with: outStream position+1 - dstIndex