readRGB
	"RGB form, use 16/32 bits"
	| val form poker sample shift |
	maxValue > 255 ifTrue:[self error:'RGB value > 32 bits not supported in Squeak'].
	stream binary.
	form _ Form extent: cols@rows depth: depth.
	poker _ BitBlt current bitPokerToForm: form.
	depth = 32 ifTrue:[shift _ 8] ifFalse:[shift _ 5].
	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x |
			val _ 0.
			1 to: 3 do: [:i |
				sample _ stream next.
				val _ val << shift + sample.
			].
			poker pixelAt: x@y put: val.
		]
	].
	^form
