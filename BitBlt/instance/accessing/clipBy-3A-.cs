clipBy: aRectangle
	| aPoint right bottom |
	right _ clipX + clipWidth.
	bottom _ clipY + clipHeight.
	aPoint _ aRectangle origin.
	aPoint x > clipX ifTrue:[clipX _ aPoint x].
	aPoint y > clipY ifTrue:[clipY _ aPoint y].
	aPoint _ aRectangle corner.
	aPoint x < right ifTrue:[right _ aPoint x].
	aPoint y < bottom ifTrue:[bottom _ aPoint y].
	clipWidth _ right - clipX.
	clipHeight _ bottom - clipY.
	clipWidth < 0 ifTrue:[clipWidth _ 0].
	clipHeight < 0 ifTrue:[clipHeight _ 0].