flipVert: evt
	"Flip the image"

| temp |
temp _ buff deepCopy flipBy: #vertical centerAt: buff center.
temp offset: 0@0.
paintingForm fillWithColor: Color transparent.
temp displayOn: paintingForm at: (paintingForm center - buff center + buff offset).

rotationButton position: (evt cursorPoint x - 6) @ rotationButton position y.
self render: bounds.
