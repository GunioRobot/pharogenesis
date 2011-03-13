emitBuffer: buffer

	| sound ratio resultBuf |

	"since some sound recording devices cannot (or will not) record below a certain sample rate,
	trim the samples down if the user really wanted fewer samples"

	(desiredSampleRate isNil or: [(ratio _ samplingRate // desiredSampleRate) <= 1]) ifTrue: [
		sound _ SampledSound new setSamples: buffer samplingRate: samplingRate.
	] ifFalse: [
		resultBuf _ SoundBuffer 
			averageEvery: ratio 
			from: buffer 
			upTo: buffer monoSampleCount.
		sound _ SampledSound new setSamples: resultBuf samplingRate: samplingRate / ratio.
	].

	recordedSound add: (codec ifNil: [sound] ifNotNil: [codec compressSound: sound])