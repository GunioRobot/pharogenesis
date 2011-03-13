pixelValueForDepth: d
	"Answer bits that appear in ONE pixel of this color in a Bitmap of the given depth. The depth must be one of 1, 2, 4, 8, 16, or 32.  Returns an integer.  Contrast with pixelWordForDepth: and bitPatternForDepth:.  Inverse is the class message colorFromPixelValue:depth:"
	"Details: For depths of 8 or less, the result is a colorMap index (zero order). For depths of 16 and 32, it is a direct color with 5 or 8 bits per color component.  6/1/96 jm, 6/14/96 tk"

	d < 8 ifTrue: [ ^ self closestPixelValueDepth: d ].
	d = 8 ifTrue: [ ^ self closestPixelValue8 ].

	d = 16 ifTrue: [
		"five bits per component; top bits ignored"
		^ (((rgb bitShift: Depth16RedShift) bitAnd: 16r7C00) bitOr:
			 ((rgb bitShift: Depth16GreenShift) bitAnd: 16r03E0)) bitOr:
			 ((rgb bitShift: Depth16BlueShift) bitAnd: 16r001F).
	].

	d = 32 ifTrue: [
		"eight bits per component; top 8 bits ignored"
		^ (((rgb bitShift: Depth32RedShift) bitAnd: 16rFF0000) bitOr:
			 ((rgb bitShift: Depth32GreenShift) bitAnd: 16r00FF00)) bitOr:
			 ((rgb bitShift: Depth32BlueShift) bitAnd: 16r0000FF).
	].

	self error: 'unknown pixel depth: ', d printString

