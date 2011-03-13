primMakeMaskOf: dataBits in: maskBits colorPixel: pixel max: max

	| highMask alpha maxLog data |
	<primitive: 'makeMaskLog' module: 'KedamaPlugin'>
	"^ KedamaSqueakPlugin doPrimitive: #makeMaskLog."


	highMask _ 16rFF000000.
	"maxLog _ self cCode: 'log(max)' inSmalltalk: [max first ln]."
	maxLog _ max first ln.
	maxLog _ 255.0 / maxLog.

	1 to: dataBits size do: [:i |
		data _ dataBits at: i.
		data = 0 ifTrue: [alpha _ 0] ifFalse: [
			"alpha _ ((255.0 / maxLog) * (self cCode: 'log(data)' inSmalltalk: [data ln])) asInteger."
			alpha _ (maxLog * (data ln)) asInteger.

		].
		(alpha > 255) ifTrue: [alpha _ 255].
		maskBits at: i put: (((alpha << 24) bitAnd: highMask) bitOr: pixel).
	].
	^ self.
