pickColorAt: aGlobalPoint 

	| alpha selfRelativePoint pickedColor |

	clickedTranslucency ifNil: [clickedTranslucency _ false].
	selfRelativePoint _ (self globalPointToLocal: aGlobalPoint) - self topLeft.
	(FeedbackBox containsPoint: selfRelativePoint) ifTrue: [^ self].
	(RevertBox containsPoint: selfRelativePoint)
		ifTrue: [^ self updateColor: originalColor feedbackColor: originalColor].

	"check for transparent color and update using appropriate feedback color "
	(TransparentBox containsPoint: selfRelativePoint) ifTrue:
		[clickedTranslucency ifFalse: [^ self].  "Can't wander into translucency control"
		alpha _ (selfRelativePoint x - TransparentBox left - 10) asFloat /
							(TransparentBox width - 20)
							min: 1.0 max: 0.0.
					"(alpha roundTo: 0.01) printString , '   ' displayAt: 0@0." " -- debug"
		self 
			updateColor: (selectedColor alpha: alpha)
			feedbackColor: (selectedColor alpha: alpha).
		^ self].

	"pick up color, either inside or outside this world"
	clickedTranslucency ifTrue: [^ self].  "Can't wander out of translucency control"
	pickedColor _ Display colorAt: aGlobalPoint.
	self 
		updateColor: (
			(selectedColor isColor and: [selectedColor isTranslucentColor])
						ifTrue: [pickedColor alpha: selectedColor alpha]
						ifFalse: [pickedColor]
		)
		feedbackColor: pickedColor