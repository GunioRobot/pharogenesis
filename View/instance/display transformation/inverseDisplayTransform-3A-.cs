inverseDisplayTransform: aPoint 
	"Answer a Point that is obtained from the argument, aPoint, by applying 
	to it the inverse of the receiver's display transformation. It is typically 
	used by the Controller of the receiver in order to convert a point in 
	display coordinates, such as the cursor point, to the local coordinate 
	system of the receiver."

	^self displayTransformation applyInverseTo: aPoint