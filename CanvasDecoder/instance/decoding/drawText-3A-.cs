drawText: command
	| boundsEnc colorEnc  text bounds color fontIndexEnc fontIndex |

	text := command at: 2.
	boundsEnc := command at: 3.
	fontIndexEnc := command at: 4.
	colorEnc := command at: 5.


	bounds _ self class decodeRectangle: boundsEnc.
	fontIndex := self class decodeInteger: fontIndexEnc.
	color _ self class decodeColor: colorEnc.

	self drawCommand: [ :c |
		c text: text bounds: bounds font: (fonts at: fontIndex) color: color ]