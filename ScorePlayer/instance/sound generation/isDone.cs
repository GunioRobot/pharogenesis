isDone

	| track |
	activeSounds size > 0  ifTrue: [^ false].
	1 to: score tracks size do: [:i |
		track _ score tracks at: i.
		(trackEventIndex at: i) <= track size ifTrue: [^ false]].
	^ true
