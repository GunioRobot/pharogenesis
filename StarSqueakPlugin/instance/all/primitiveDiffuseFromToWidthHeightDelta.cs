primitiveDiffuseFromToWidthHeightDelta
	"Diffuse the integer values of the source patch variable Bitmap into the output Bitmap. Each cell of the output is the average of the NxN area around it in the source, where N = (2 * delta) + 1."

	| srcOop dstOop height width delta src dst area startY endY startX endX sum rowStart |
	self export: true.
	self var: 'src' declareC: 'unsigned int *src'.
	self var: 'dst' declareC: 'unsigned int *dst'.

	srcOop _ interpreterProxy stackValue: 4.
	dstOop _ interpreterProxy stackValue: 3.
	width _ interpreterProxy stackIntegerValue: 2.
	height _ interpreterProxy stackIntegerValue: 1.
	delta _ interpreterProxy stackIntegerValue: 0.
	src _ self checkedUnsignedIntPtrOf: srcOop.
	dst _ self checkedUnsignedIntPtrOf: dstOop.
	interpreterProxy success:
		(interpreterProxy stSizeOf: srcOop) = (interpreterProxy stSizeOf: dstOop).
	interpreterProxy success:
		(interpreterProxy stSizeOf: srcOop) = (width * height).
	interpreterProxy failed ifTrue: [^ nil].

	area _ ((2 * delta) + 1) * ((2 * delta) + 1).
	0 to: height - 1 do: [:y |
		startY _ y - delta.
		startY < 0 ifTrue: [startY _ 0].
		endY _ y + delta.
		endY >= height ifTrue: [endY _ height - 1].
		0 to: width - 1 do: [:x |
			startX _ x - delta.
			startX < 0 ifTrue: [startX _ 0].
			endX _ x + delta.
			endX >= width ifTrue: [endX _ width - 1].

			sum _ 0.
			startY to: endY do: [:y2 |
				rowStart _ y2 * width.
				startX to: endX do: [:x2 |
					sum _ sum + (src at: rowStart + x2)]].

			dst at: ((y * width) + x) put: (sum // area)]].

	interpreterProxy pop: 5.  "pop args, leave rcvr on stack"
