drawOn: aCanvas
	| interval delta frame x0 x1 y0 y1 deltaX deltaY  hilitColor shadowColor |
	super drawOn: aCanvas.		"border & background"
	borderColor isColor
		ifTrue: [hilitColor _ shadowColor _ borderColor]
		ifFalse: [hilitColor := color lighter lighter.
			shadowColor := color darker darker].
	frame := self innerBounds insetBy: 2.
	aCanvas frameAndFillRectangle: frame fillColor: color
		borderWidth: 1 topLeftColor: hilitColor bottomRightColor: shadowColor.
	frame _ frame insetBy: (borderColor isColor ifTrue: [1] ifFalse: [2]).
	x0 := frame origin x.
	x1 := frame corner x.
	y0 := frame origin y.
	y1 := frame corner y.
	deltaX := (x1 - x0) / 2.
	deltaY := (y1 - y0) / 2.
	interval := 10.
	delta := self angle \\ interval.
	1 to: (self maxAngle / (2 * interval)) rounded do: [ :i |
		| x y |
		self isHorizontal ifTrue: [
			x := x0 + deltaX - (((i * interval + delta) * (2 * Float pi / 360.0)) cos * deltaX).
			aCanvas fillRectangle: (Rectangle origin: (x-1)@y0 corner: x@y1) color: hilitColor.
			borderColor isColor ifFalse:
				 [aCanvas fillRectangle: (Rectangle origin: x@y0 corner: (x+1)@y1) color: shadowColor]]
		ifFalse: [
			y := y0 + deltaY - (((i * interval + delta) * (2 * Float pi / 360.0)) cos * deltaY).
			aCanvas fillRectangle: (Rectangle origin: x0@(y-1) corner: x1@y) color: hilitColor.
			borderColor isColor ifFalse:
				 [aCanvas fillRectangle: (Rectangle origin: x0@y corner: x1@(y+1)) color: shadowColor]]]