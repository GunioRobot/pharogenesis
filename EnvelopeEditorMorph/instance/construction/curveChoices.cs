curveChoices
	| extant others |
	extant _ sound envelopes collect: [:env | env name].
	others _ #('volume' 'modulation' 'pitch' 'ratio') reject: [:x | extant includes: x].
	^ (extant collect: [:name | 'edit ' , name])
	, (others collect: [:name | 'add ' , name])
	, (sound envelopes size > 1
		ifTrue: [Array with: 'remove ' , envelope name]
		ifFalse: [Array new])