mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play a collection of sounds in sequence."
	"(RepeatingSound new
		setSound: FMSound majorScale
		iterations: 2) play"

	| i count samplesNeeded |
	iteration <= 0 ifTrue: [^ self].
	i _ startIndex.
	samplesNeeded _ n.
	[samplesNeeded > 0] whileTrue: [
		count _ sound samplesRemaining min: samplesNeeded.
		count = 0 ifTrue: [
			iterationCount == #forever
				ifFalse: [
					iteration _ iteration - 1.
					iteration <= 0 ifTrue: [^ self]].  "done"
			sound reset.
			count _ sound samplesRemaining min: samplesNeeded.
			count = 0 ifTrue: [^ self]].  "zero length sound"
		sound mixSampleCount: count
			into: aSoundBuffer
			startingAt: i
			leftVol: leftVol
			rightVol: rightVol.
		i _ i + count.
		samplesNeeded _ samplesNeeded - count].
