onScore: aMIDIScore

	| trackCount totalVol incr curr pan |
	score _ aMIDIScore.
	trackCount _ score tracks size.
	durationInTicks _ score durationInTicks.
	instruments _ (1 to: trackCount) collect: [:i | FMSound oboe1].
	leftVols _ Array new: trackCount.
	rightVols _ Array new: trackCount.
	muted  _ Array new: trackCount withAll: false.
	rate _ 1.0.
	repeat _ false.
	tempo _ 120.0.

	trackCount = 0 ifTrue: [^ self].
	1 to: trackCount do: [:i |
		leftVols at: i put: ScaleFactor // 4.
		rightVols at: i put: ScaleFactor // 4].

	"distribute inital panning of tracks left-to-right"
	totalVol _ 1.0.
	incr _ totalVol / (((trackCount // 2) + 1) * 2).
	curr _ 0.
	1 to: trackCount do: [:t |
		t even
			ifTrue: [pan _ curr]
			ifFalse: [
				curr _ curr + incr.
				pan _ totalVol - curr].
		self panForTrack: t put: pan].

