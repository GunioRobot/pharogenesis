drawForForm: aForm on: aCanvas
	"Draw a small view of the given form on the canvas"

	| scale shrunkForm viewedObjectBox interimCanvas |
	viewedObjectBox _ aForm boundingBox.
	scale _  self innerBounds width / (viewedObjectBox width max: viewedObjectBox height).
	interimCanvas _ Display defaultCanvasClass extent: viewedObjectBox extent depth: aCanvas depth.
	interimCanvas translateBy: viewedObjectBox topLeft negated 
				during: [:tempCanvas | tempCanvas drawImage: aForm at: 0@0].
	shrunkForm _ interimCanvas form magnify: interimCanvas form boundingBox by: scale smoothing: 1.
	lastFormShown _ shrunkForm.

	aCanvas paintImage: shrunkForm at: self center - shrunkForm boundingBox center