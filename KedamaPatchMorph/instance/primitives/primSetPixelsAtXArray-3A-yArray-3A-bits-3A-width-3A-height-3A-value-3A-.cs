primSetPixelsAtXArray: xArray yArray: yArray bits: bits width: width height: height value: value

	| v |
	<primitive: 'primSetPixelsAtXY' module: 'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #primSetPixelsAtXY."

	value isNumber ifTrue: [v _ value].
	1 to: xArray size do: [:i |
		value isNumber ifFalse: [
			v _ value at: i.
		].		
		self pixelAtX: (xArray at: i) y: (yArray at: i) put: v.
	].
