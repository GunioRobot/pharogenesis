pickColorAt: aPoint 

	"RAA 27 Nov 99 - aPoint is global, so no need to add viewbox topleft"

	| worldBox globalP c alpha localPt |

	localPt _ aPoint - self topLeft.
	(FeedbackBox containsPoint: localPt) ifTrue: [^ self].
	(RevertBox containsPoint: localPt)
		ifTrue: [^ self updateColor: originalColor feedbackColor: originalColor].

	"pick up color, either inside or outside this world"
	worldBox _ self world viewBox.
	globalP _ aPoint 		"+ worldBox topLeft".
	"get point in screen coordinates"
	(worldBox containsPoint: globalP)
		ifTrue: [c _ self world colorAt: aPoint belowMorph: Morph new]
		ifFalse: [c _ Display colorAt: globalP].

	"check for transparent color and update using appropriate feedback color "
	(TransparentBox containsPoint: localPt)
		ifTrue: [alpha _ (aPoint x - bounds left - TransparentBox left - 10) asFloat /
							(TransparentBox width - 20)
							min: 1.0 max: 0.0.
					"(alpha roundTo: 0.01) printString , '   ' displayAt: 0@0." " -- debug"
					self updateColor: (selectedColor alpha: alpha)
						feedbackColor: (selectedColor alpha: alpha)]
		ifFalse: [self updateColor: ((selectedColor isColor and: [selectedColor isTranslucentColor])
					ifTrue: [c alpha: selectedColor alpha]
					ifFalse: [c])
				feedbackColor: c]