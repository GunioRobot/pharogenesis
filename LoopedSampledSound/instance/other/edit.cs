edit
	"Open a WaveEditor on this sound."

	| loopLen ed |
	loopLen _ scaledLoopLength asFloat / LoopIndexScaleFactor.
	ed _ WaveEditor new
		data: leftSamples;
		samplingRate: originalSamplingRate;
		loopEnd: loopEnd;
		loopLength: loopLen;
		loopCycles: (loopLen / (originalSamplingRate asFloat / perceivedPitch)) rounded.
	ed openInWorld.
