primPixelsAtXArray: xArray yArray: yArray bits: bits width: width height: height into: aWordArray
	| x y formIndex val |
	<primitive: 'primPixelsAtXY' module: 'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #primPixelsAtXY."
	1 to: aWordArray size do: [:i |
		val _ nil.
		x _ (xArray at: i) truncated.
		y _ (yArray at: i) truncated.
		((x < 0) or: [y < 0]) ifTrue: [val _ 0].
		((x >= form width) or: [y >= form height]) ifTrue: [val _ 0].
		val ifNil: [
			formIndex _ ((y * form width) + x) + 1.
			val _ bits at: formIndex.
		].
		aWordArray at: i put: val.
	].
