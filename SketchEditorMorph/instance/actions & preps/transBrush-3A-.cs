transBrush: evt
	"Paint with a semi-transparent brush.  Call this each stroke.  , di"

	|  prevP p buffSize theta brushRect buffRect delta newBuffRect updateRect scale half |
	scale _ buffToPic cellSize.	"2"
	buffSize _ (buff width - brush width) // scale.	"100"
	half _ brush extent // 2.	"center"
	"buffRect now relative to pictureForm"
	buffRect _ (evt cursorPoint - bounds origin) - (buff extent // scale // 2) 
		extent: buff extent // scale.
	picToBuff copyQuad: buffRect innerCorners toRect: buff boundingBox.
	prevP _ ((evt cursorPoint - bounds origin) - buffRect origin) * scale - half.
	[Sensor redButtonPressed] whileTrue:
		[p _ ((evt cursorPoint - bounds origin) - buffRect origin) * scale - half.
				"p, prevP are rel to buff origin"
		p ~= prevP ifTrue: [
		(p dist: prevP) > buffSize ifTrue:
			["Stroke too long to fit in buffer -- clip to buffer,
				and next time through will do more of it"
			theta _ (p-prevP) theta.
			p _ ((theta cos@theta sin) * (buffSize-2) asFloat + prevP) truncated].
		brushRect _ p extent: brush extent.
		((buff boundingBox insetBy: scale) containsRect: brushRect) ifFalse:
			["Brush is out of buffer region.  Scroll the buffer,
				and fill new areas from the display"
			delta _ (brushRect amountToTranslateWithin: 
				(buff boundingBox insetBy: scale)) // scale.
			buffToBuff copyFrom: buff boundingBox in: buff to: delta*scale.
			newBuffRect _ buffRect translateBy: delta negated.
			p _ p translateBy: delta*scale.
			prevP _ prevP translateBy: delta*scale.
			(newBuffRect areasOutside: buffRect) do:
				[:r | picToBuff copyQuad: r innerCorners 
						toRect: (r origin - newBuffRect origin*scale extent: r extent*scale)].
			buffRect _ newBuffRect].

		"Interpolate from prevP to p..."
		brushToBuff drawFrom: prevP to: p withFirstPoint: false.

		"Update only the altered pixels of the destination"
		updateRect _ (p min: prevP) corner: (p max: prevP) + brush extent.
		updateRect _ updateRect origin // scale * scale
				corner: updateRect corner + scale // scale * scale.
		"And finally store into the painting"
"buff displayAt: 0@0."
		buffToPic copyQuad: updateRect innerCorners
					toRect: (updateRect origin // scale + buffRect origin
								extent: updateRect extent // scale).
		prevP _ p.
		self render: (updateRect origin // scale + buffRect origin
										extent: updateRect extent // scale)]].