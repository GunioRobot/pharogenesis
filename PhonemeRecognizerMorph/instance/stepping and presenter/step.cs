step
	"Update the record light, level meter, and display."

	| w buf |
	"update the record light and level meter"
	soundInput isRecording
		ifTrue: [statusLight color: Color yellow]
		ifFalse: [statusLight color: Color gray].
	w := ((121 * soundInput meterLevel) // 100) max: 1.
	levelMeter width ~= w ifTrue: [levelMeter width: w].

	soundInput isRecording ifTrue: [
		[soundInput bufferCount > 0] whileTrue: [
			"skip to the most recent buffer"
			buf := soundInput nextBufferOrNil].
		buf ifNotNil: [
			currentPhoneme := recognizer findMatchFor: buf samplingRate: soundInput samplingRate.
			phonemeDisplay contents: currentPhoneme name]].

