paint: newEvent
	| bb newPosition dx firstY lastY dy py midX |
	newPosition _ newEvent getVertex texCoords * currentCanvas extent - (currentNib extent // 2).
	"Watch out for wrapping in y"
	(newPosition y - currentPosition y) abs > (currentCanvas form height // 2) ifTrue:[
		"Go the other (shorter) way around"
		dx _ newPosition x - currentPosition x.
		newPosition y > currentPosition y ifTrue:[
			firstY _ 0. lastY _ currentCanvas form height.
			dy _ currentCanvas form height - newPosition y + currentPosition y.
			py _ currentPosition y.
		] ifFalse:[
			firstY _ currentCanvas form height. lastY _ 0.
			dy _ currentCanvas form height - currentPosition y + newPosition y.
			py _ currentCanvas form height - currentPosition y.
		].
		midX _ currentPosition x + (dx * (py / dy)).
		midX _ midX asInteger.
	].
	bb _ BitBlt toForm: currentCanvas form.
	bb 
		sourceForm: currentNib; 
		sourceRect: currentNib boundingBox;
		colorMap: (currentNib colormapIfNeededFor: bb destForm);
		combinationRule: Form blend.
	midX == nil ifTrue:[
		bb drawFrom: currentPosition asIntegerPoint to: newPosition asIntegerPoint.
	] ifFalse:[
		bb 
			drawFrom: currentPosition asIntegerPoint to: midX @ firstY;
			drawFrom: midX @ lastY to: newPosition asIntegerPoint.
	].
	currentPosition _ newPosition.