readPlainRGB
	"RGB form, use 32 bits"
	| val form poker tokens aux |
	maxValue > 255 ifTrue:[self error:'RGB value > 32 bits not supported in Squeak'].
	form _ Form extent: cols@rows depth: 32.
	poker _ BitBlt current bitPokerToForm: form.
	tokens _ OrderedCollection new.
	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x | | r g b|
			aux _ self getTokenPbm: tokens. r _ aux at: 1. tokens _ aux at: 2.
			aux _ self getTokenPbm: tokens. g _ aux at: 1. tokens _ aux at: 2.
			aux _ self getTokenPbm: tokens. b _ aux at: 1. tokens _ aux at: 2.
			val _ self r: r g: g b: b for: depth.
			poker pixelAt: x@y put: val.
		]
	].
	^form
