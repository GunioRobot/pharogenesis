onScore: aMIDIScore

	| n totalVol incr curr vol |
	score _ aMIDIScore.
	n _ score tracks size.
	instruments _ (1 to: n) collect: [:i | FMSound oboe1].
	leftVols _ Array new: n.
	rightVols _ Array new: n.
	muted  _ Array new: n withAll: false.
	rate _ 1.0.
	repeat _ false.
	tempo _ 120.0.

	n = 0 ifTrue: [^ self].
	n = 1 ifTrue: [  "center solo voice"
		leftVols at: i put: ScaleFactor // 8.
		rightVols at: i put: ScaleFactor // 8.
		^ self].
		
	"distribute inital panning of tracks left-to-right"
	totalVol _ ScaleFactor // (2 * n).
	incr _ totalVol // (((n // 2) + 1) * 2).
	curr _ 0.
	1 to: n do: [:i |
		i even
			ifTrue: [vol _ curr]
			ifFalse: [
				curr _ curr + incr.
				vol _ totalVol - curr].
		leftVols at: i put: vol.
		rightVols at: i put: (totalVol - vol)].
