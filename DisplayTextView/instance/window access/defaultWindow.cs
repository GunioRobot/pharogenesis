defaultWindow 
	"Refer to the comment in View|defaultWindow."

	^self inverseDisplayTransform: (editParagraph boundingBox expandBy: 6 @ 6)