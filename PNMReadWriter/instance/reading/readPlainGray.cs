readPlainGray
	"plain gray"
	| val form poker aux tokens |
	form _ Form extent: cols@rows depth: depth.
	poker _ BitBlt current bitPokerToForm: form.
	tokens _ OrderedCollection new.
	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x |
			aux _ self getTokenPbm: tokens.
			val _ aux at: 1. tokens _ aux at: 2.
			poker pixelAt: x@y put: val.
		]
	].
	^form
