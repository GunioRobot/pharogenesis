bigMacPaintOn: stream
	| wLimit hLimit |
	width <= height 
		ifTrue: [wLimit _ 576. hLimit _ 720]
		ifFalse: [wLimit _ 720.	hLimit _ 576].

	(width <= wLimit and: [height <= hLimit])
		ifTrue: [^ self macPaintOn: stream].

	(width > 576 and: [width <= 720]) ifTrue:		"subdivide along height using 576"
		[^ self divideOn: stream extent: width@576 restOrigin: 0@576 restName: 'b'].
	(height > 576 and: [height <= 720]) ifTrue:	"subdivide along width using 576"
		[^ self divideOn: stream extent: 576@height restOrigin: 576@0 restName: 'a'].

	width > wLimit ifTrue:	"subdivide along width first"
		[^ self divideOn: stream extent: wLimit@height restOrigin: wLimit@0 restName: 'a'].

	"subdivide along height"
	self divideOn: stream extent: width@hLimit restOrigin: 0@hLimit restName: 'b'.
