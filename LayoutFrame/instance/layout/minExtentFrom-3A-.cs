minExtentFrom: minExtent
	"Return the minimal extent the given bounds can be represented in"
	| widthFraction heightFraction width height |
	widthFraction _ 1.0.
	leftFraction ifNotNil:[widthFraction _ widthFraction + leftFraction].
	rightFraction ifNotNil:[widthFraction _ widthFraction + rightFraction].
	heightFraction _ 1.0.
	topFraction ifNotNil:[heightFraction _ heightFraction + topFraction].
	bottomFraction ifNotNil:[heightFraction _ heightFraction + bottomFraction].
	width _ minExtent x * widthFraction.
	height _ minExtent y * heightFraction.
	leftOffset ifNotNil:[width _ width + leftOffset].
	rightOffset ifNotNil:[width _ width + rightOffset].
	topOffset ifNotNil:[height _ height + topOffset].
	bottomOffset ifNotNil:[height _ height + bottomOffset].
	^width truncated @ height truncated