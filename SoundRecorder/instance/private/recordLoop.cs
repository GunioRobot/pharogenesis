recordLoop
	"Record process loop that records samples."

	| n sampleCount |
	n _ 0.
	[true] whileTrue: [
		n = 0 ifTrue: [bufferAvailableSema wait].
		paused
			ifTrue: [
				n _ self primRecordSamplesInto: meteringBuffer startingAt: 1.
				self meterFrom: 1 count: n in: meteringBuffer]
			ifFalse: [
				n _ self primRecordSamplesInto: currentBuffer startingAt: nextIndex.
				self meterFrom: nextIndex count: n in: currentBuffer.
				nextIndex _ nextIndex + n.
				stereo
					ifTrue: [sampleCount _ currentBuffer stereoSampleCount]
					ifFalse: [sampleCount _ currentBuffer monoSampleCount].
				nextIndex > sampleCount
					ifTrue: [
						self emitBuffer: currentBuffer.
						self allocateBuffer]]].
