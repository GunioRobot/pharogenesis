displaySpecial 
	"The receiver has a special highlight form. Use it for displaying 
	complemented, if appropriate."

	complemented
		ifTrue: [self displaySpecialComplemented].
	label == nil 
		ifFalse: [label
					displayOn: Display
					transformation: self displayTransformation
					clippingBox: self insetDisplayBox
					align: label boundingBox center
					with: label boundingBox center
					rule: Form under
					fillColor: nil]