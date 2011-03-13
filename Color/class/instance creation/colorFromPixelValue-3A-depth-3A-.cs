colorFromPixelValue: p depth: d
	"Convert a pixel value for the given display depth into a color."
	"Details: For depths of 8 or less, the pixel value is simply looked
	 up in a table. For depths of 16 and 32, the color components are
	 extracted and converted into a color."

	| r g b |
	d = 1 ifTrue: [ ^ IndexedColors at: (p bitAnd: 16r01) + 1 ].
	d = 2 ifTrue: [ ^ IndexedColors at: (p bitAnd: 16r03) + 1 ].
	d = 4 ifTrue: [ ^ IndexedColors at: (p bitAnd: 16r0F) + 1 ].
	d = 8 ifTrue: [ ^ IndexedColors at: (p bitAnd: 16rFF) + 1 ].

	d = 16 ifTrue: [
		"five bits per component; top bit ignored"
		r _ (p bitShift: -10) bitAnd: 16r1F.
		g _ (p bitShift:  -5) bitAnd: 16r1F.
		b _ p bitAnd: 16r1F.
		^ self red: r green: g blue: b range: 31
	].

	d = 32 ifTrue: [
		"eight bits per component; top 8 bits ignored"
		r _ (p bitShift: -16) bitAnd: 16rFF.
		g _ (p bitShift:  -8) bitAnd: 16rFF.
		b _ p bitAnd: 16rFF.
		^ self red: r green: g blue: b range: 255
	].

	self error: 'unknown pixel depth: ', d printString
