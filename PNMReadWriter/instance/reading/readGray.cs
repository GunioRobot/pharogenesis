readGray
	"gray form"
	| val form poker |
	maxValue > 255 ifTrue:[self error:'Gray value > 8 bits not supported in Squeak'].
	stream binary.
	form _ Form extent: cols@rows depth: depth.
	poker _ BitBlt current bitPokerToForm: form.
	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x |
			val _ stream next.
			poker pixelAt: x@y put: val.
		]
	].
	^form
