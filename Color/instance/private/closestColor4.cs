closestColor4
	"Return the nearest approximation to this color for a 4-bit deep Form."

	| bIndex |
	self halt. "old"
	self = PureYellow ifTrue: [ ^ 16r33333333 ].
	self = PureRed ifTrue: [ ^ 16r44444444 ].
	self = PureGreen ifTrue: [ ^ 16r55555555 ].
	self = PureBlue ifTrue: [ ^ 16r66666666 ].
	self = PureCyan ifTrue: [ ^ 16r77777777 ].
	self = PureMagenta ifTrue: [ ^ 16r88888888 ].

	bIndex _ (self brightness * 8.0) rounded.  "bIndex in [0..8]"
	^ #(
		16r11111111			"black"
		16r99999999			"7/8 gray"
		16rAAAAAAAA	"6/8 gray"
		16rBBBBBBBB		"5/8 gray"
		16rCCCCCCCC		"4/8 gray"
		16rDDDDDDDD		"3/8 gray"
		16rEEEEEEEE		"2/8 gray"
		16rFFFFFFFF		"1/8 gray"
		16r00000000			"white"
	) at: bIndex + 1

