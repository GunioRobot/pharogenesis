readTrimmedSamplesFromAIFF: fileName
	"Read samples from the given AIFF file and trim off leading and trailing silence."

	| data first last i s |
	data _ (FileStream oldFileNamed: fileName) binary contentsOfEntireFile.
	first _ last _ nil.
	i _ 55.
	[(first == nil) and: [i < data size]] whileTrue: [
		s _ data at: i.
		s > 127 ifTrue: [s _ s - 256].
		s abs > 10 ifTrue: [first _ i].
		i _ i + 1].
	first ifNil: [^ SoundBuffer new].  "all silence"
	i _ data size.
	[(last == nil) and: [i > first]] whileTrue: [
		s _ data at: i.
		s > 127 ifTrue: [s _ s - 256].
		s abs > 10 ifTrue: [last _ i].
		i _ i - 1].
	^ self convert8bitSignedTo16Bit: (data copyFrom: first to: last)
