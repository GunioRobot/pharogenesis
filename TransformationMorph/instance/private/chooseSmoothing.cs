chooseSmoothing
	"Choose appropriate smoothing, after a change of scale or rotation."

	(self scale < 1.0 or: [self angle ~= (self angle roundTo: Float pi / 2.0)])
		ifTrue: [smoothing _ 2]
		ifFalse: [smoothing _ 1]