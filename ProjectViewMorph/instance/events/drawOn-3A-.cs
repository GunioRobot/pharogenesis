drawOn: aCanvas

	project ifNil: [^ super drawOn: aCanvas].
	project isInMemory ifFalse: [^ super drawOn: aCanvas].	"use lastProjectThumbnail"
	project class == DiskProxy ifTrue: [^ super drawOn: aCanvas].	"still on server"
	project thumbnail ifNil: [
		image fill: (0@0 extent: image extent) rule: Form over 
			fillColor: project defaultBackgroundColor.
		^ super drawOn: aCanvas].
	project thumbnail ~~ lastProjectThumbnail ifTrue:
			["scale thumbnail to fit my bounds"
			(WarpBlt current toForm: image)
				sourceForm: project thumbnail;
				cellSize: 2;  "installs a colormap"
				combinationRule: Form over;
				copyQuad: (project thumbnail boundingBox) innerCorners
				toRect: (0@0 extent: image extent).
			lastProjectThumbnail _ project thumbnail.
			image borderWidth: 1].

	super drawOn: aCanvas.
