magnifiedForm
	| srcRect form exclusion |
	lastPos _ self sourcePoint.
	srcRect _ self sourceRectFrom: lastPos.
	((srcRect intersects: self bounds) and: [ RecursionLock == nil ])
		ifTrue: [RecursionLock _ self.
				self isRound
					ifTrue: [exclusion _ owner]
					ifFalse: [exclusion _ self].
				form _ self world patchAt: srcRect without: exclusion andNothingAbove: false.
				RecursionLock _ nil]
		ifFalse: ["cheaper method if the source is not occluded"
				form _ Display copy: srcRect].
	"smooth if non-integer scale"
	^ form magnify: form boundingBox
		by: magnification
		smoothing: (magnification isInteger ifTrue: [1] ifFalse: [2])