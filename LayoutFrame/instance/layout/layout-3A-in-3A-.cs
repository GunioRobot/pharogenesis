layout: oldBounds in: newBounds
	"Return the proportional rectangle insetting the given bounds"
	| left right top bottom |
	leftFraction ifNotNil:[
		left _ newBounds left + (newBounds width * leftFraction).
		leftOffset ifNotNil:[left _ left + leftOffset]].
	rightFraction ifNotNil:[
		right _ newBounds right - (newBounds width * (1.0 - rightFraction)).
		rightOffset ifNotNil:[right _ right + rightOffset]].
	topFraction ifNotNil:[
		top _ newBounds top + (newBounds height * topFraction).
		topOffset ifNotNil:[top _ top + topOffset]].
	bottomFraction ifNotNil:[
		bottom _ newBounds bottom - (newBounds height * (1.0 - bottomFraction)).
		bottomOffset ifNotNil:[bottom _ bottom + bottomOffset]].
	left ifNil:[ right 
			ifNil:[left _ oldBounds left. right _ oldBounds right]
			ifNotNil:[left _ right - oldBounds width]].
	right ifNil:[right _ left + oldBounds width].
	top ifNil:[ bottom 
			ifNil:[top _ oldBounds top. bottom _ oldBounds bottom]
			ifNotNil:[top _ bottom - oldBounds height]].
	bottom ifNil:[bottom _ top + oldBounds height].
	^(left rounded @ top rounded) corner: (right rounded @ bottom rounded)