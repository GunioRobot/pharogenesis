fullDrawOn: aCanvas
	| mergeForm |
	submorphs size = 2 ifFalse: [^ super fullDrawOn: aCanvas].
	(aCanvas isVisible: self fullBounds) ifFalse: [^ self].
	"self drawOn: aCanvas."
	displayMode == #showScreenOnly ifTrue:
		[self screenMorph fullDrawOn: aCanvas].
	displayMode == #showSourceOnly ifTrue:
		[self sourceMorph fullDrawOn: aCanvas].
	screenForm ifNil:
		[self mapColor: Color black to: 16rFFFFFFFF othersTo: 0].
	displayMode == #showScreenOverSource ifTrue:
		[self sourceMorph fullDrawOn: aCanvas.
		aCanvas image: screenForm at: self position].
	displayMode == #showScreened ifTrue:
		[mergeForm _ self sourceMorph imageFormForRectangle: self bounds.
		(BitBlt toForm: mergeForm) copyForm: screenForm to: 0@0 rule: Form and
			colorMap: (Bitmap with: 0 with: 16rFFFFFFFF).
		aCanvas image: mergeForm at: self position]