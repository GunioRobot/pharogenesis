primMakeMaskOf: dataBits in: maskBits colorPixel: pixel shift: shift

	| highMask data alpha |
	<primitive: 'makeMask' module: 'KedamaPlugin'>
	"^ KedamaSqueakPlugin doPrimitive: #makeMask."

	highMask _ 16rFF000000.
	1 to: dataBits size do: [:i |
		data _ dataBits at: i.
		alpha _ data bitShift: shift.
		(alpha > 255) ifTrue: [alpha _ 255].
		maskBits at: i put: (((alpha << 24) bitAnd: highMask) bitOr: pixel).
	].

	^ self.
