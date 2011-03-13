adjustAfter: changeBlock 
	"Cause this morph to remain cetered where it was before, and
	choose appropriate smoothing, after a change of scale or rotation."
	| oldRefPos |
	oldRefPos := self referencePosition.
	changeBlock value.
	self chooseSmoothing.
	self layoutChanged.
	owner ifNotNil: [owner invalidRect: bounds]
