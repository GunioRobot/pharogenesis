readData
	"generic data"
	| data nBits nBytes val sample |
	stream binary.
	data _ OrderedCollection new.
	nBits _ maxValue floorLog:2.
	nBytes _ (nBits+1) >> 3.
	(nBits+1 rem: 8) > 0 ifTrue:[nBytes _ nBytes+1].

	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x |
			val _ 0.
			1 to: nBytes do: [:n |
				sample _ stream next.
				val _ val << 8 + sample.
			].
			data add: val.
		]
	].
	^data

