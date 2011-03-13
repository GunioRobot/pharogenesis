labelTextRegion
	| topLeft |
	labelText == nil ifTrue: [^ self labelDisplayBox center extent: 0@0].
	topLeft _ self labelDisplayBox center
		+ (labelText boundingBox topLeft - labelText boundingBox center).
	^ topLeft extent: labelText boundingBox extent