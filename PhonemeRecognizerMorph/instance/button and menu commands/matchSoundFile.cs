matchSoundFile
	"Process an AIFF or WAV sound file and generate a sequence of phoneme matches for that file in the Transcript. When done, open an inspector on the resulting collection of phonemes."

	| fileName snd out fftSize samplesPerInterval startIndex buf p |
	self inform: 'Sorry, sound file matching is not yet implemented'.
	fileName _ Utilities
		chooseFileWithSuffixFromList: #('.aif' '.aiff' '.wav')
		withCaption: 'Sound file?'.
	fileName = #none ifTrue: [^ self inform: 'No sound files.'].

	('*aif*' match: fileName) ifTrue:
		[snd _ SampledSound fromAIFFfileNamed: fileName].
	('*wav' match: fileName) ifTrue:
		[snd _ SampledSound fromWaveFileNamed: fileName].

	out _ OrderedCollection new: 1000.
	fftSize _ PhonemeRecord fftSize.
	samplesPerInterval _ snd samplingRate / 24.0.
	1 to: (snd samples size - fftSize) + 1 by: samplesPerInterval do: [:i |
		startIndex _ i truncated.
		buf _ snd samples copyFrom: startIndex to: startIndex + fftSize - 1.
		out addLast: (p _
			self findMatchFor: buf samplingRate: snd samplingRate).
p name asParagraph display.
(SampledSound samples: buf samplingRate: 11025) playAndWaitUntilDone.
].
	out asArray inspect.
