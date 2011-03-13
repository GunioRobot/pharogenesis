compressSound: aSound atRate: desiredSampleRate
	"Compress the entirety of the given sound with this codec. Answer a CompressedSoundData."

	| compressed channels samples newRate ratio buffer |

	compressed _ CompressedSoundData new
		codecName: self class name;
		soundClassName: aSound class name.
	(aSound isKindOf: SampledSound) ifTrue: [
		(desiredSampleRate isNil or: 
				[(ratio _ aSound originalSamplingRate // desiredSampleRate) <= 1]) ifTrue: [
			samples _ aSound samples.
			newRate _ aSound originalSamplingRate.
		] ifFalse: [
			buffer _ aSound samples.
			samples _ SoundBuffer 
				averageEvery: ratio 
				from: buffer 
				upTo: buffer monoSampleCount.
			newRate _ aSound originalSamplingRate / ratio.
		].

		channels _ Array new: 1.
		channels at: 1 put: (self encodeSoundBuffer: samples).
		compressed
			channels: channels;
			samplingRate: newRate;
			firstSample: 1;
			loopEnd: samples size;
			loopLength: 0.0;
			perceivedPitch: 100.0;
			gain: aSound loudness.
		^ compressed].
	(aSound isKindOf: LoopedSampledSound) ifTrue: [
		aSound isStereo
			ifTrue: [
				channels _ Array new: 2.
				channels at: 1 put: (self encodeSoundBuffer: aSound leftSamples).
				channels at: 2 put: (self encodeSoundBuffer: aSound rightSamples)]
			ifFalse: [
				channels _ Array new: 1.
				channels at: 1 put: (self encodeSoundBuffer: aSound leftSamples)].
		compressed
			channels: channels;
			samplingRate: aSound originalSamplingRate;
			firstSample: aSound firstSample;
			loopEnd: aSound loopEnd;
			loopLength: aSound loopLength;
			perceivedPitch: aSound perceivedPitch;
			gain: aSound gain.
		^ compressed].
	self error: 'you can only compress sampled sounds'.
