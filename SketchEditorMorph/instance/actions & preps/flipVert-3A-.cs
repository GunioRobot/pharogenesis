flipVert: evt 
	"Flip the image"
	| temp myBuff |

	myBuff _ self get: #buff for: evt.
	temp _ myBuff deepCopy flipBy: #vertical centerAt: myBuff center.
	temp offset: 0 @ 0.
	paintingForm fillWithColor: Color transparent.
	temp displayOn: paintingForm at: paintingForm center - myBuff center + myBuff offset.
	rotationButton position: evt cursorPoint x - 6 @ rotationButton position y.
	self render: bounds