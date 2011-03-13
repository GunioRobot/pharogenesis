computeForm
	"Compute and answer a Form to be displayed for
	this menu."
	| borderInset paraForm menuForm inside |
	borderInset := 4 @ 4. 
	paraForm := (DisplayText text: labelString asText textStyle: MenuStyle) form.
	menuForm := Form extent: paraForm extent + (borderInset * 2) depth: paraForm depth.
	menuForm
		fill: (0 @ 0 extent: menuForm extent)
		rule: Form over
		fillColor: Color white.
	menuForm borderWidth: 2.
	paraForm displayOn: menuForm at: borderInset.
	lineArray == nil
		ifFalse: [lineArray
				do: [:line | menuForm
						fillBlack: (4 @ (line * font height + borderInset y) extent: menuForm width - 8 @ 1)]].
	frame := Quadrangle new.
	frame region: menuForm boundingBox.
	frame borderWidth: 4.
	inside := frame inside.
	marker := inside topLeft extent: inside width @ MenuStyle lineGrid.
	selection := 1.
	^ form := menuForm