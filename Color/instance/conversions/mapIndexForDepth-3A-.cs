mapIndexForDepth: d
	"Return the index corresponding to this color in a 512-entry color transformation map. RGB forms collapse to 3 bits per color when indexing into such a colorMap."

	| colorValue bpc r g b |
	colorValue _ self pixelValueForDepth: d.
	d <= 8 ifTrue: [ ^ colorValue + 1 ].
	d = 16
		ifTrue: [ bpc _ 5 ]  "5 bits per color"
		ifFalse: [ bpc _ 8 ].  "8 bits per color"

	r _ (colorValue bitShift: 3 - bpc - bpc - bpc) bitAnd: 7.
	g _ (colorValue bitShift: 3 - bpc - bpc) bitAnd: 7.
	b _ (colorValue bitShift: 3 - bpc) bitAnd: 7.
	^ (r bitShift: 6) + (g bitShift: 3) + b + 1
	"Is this pre or post G and B switch???"