fullDrawOn: aCanvas
	| mergeForm |
	submorphs size = 0 ifTrue: [^ super fullDrawOn: aCanvas].
	(submorphs size = 1 or: [displayMode == #showScreenOnly]) ifTrue:
		[^ aCanvas fullDrawMorph: self screenMorph].
	displayMode == #showSourceOnly ifTrue:
		[^ aCanvas fullDrawMorph: self sourceMorph].
	displayMode == #showScreenOverSource ifTrue:
		[aCanvas fullDrawMorph: self sourceMorph.
		^ aCanvas fullDrawMorph: self screenMorph].
	displayMode == #showScreened ifTrue:
		[aCanvas fullDrawMorph: self screenMorph.
		self flag: #fixCanvas. "There should be a more general way than this"
		mergeForm _ self sourceMorph imageFormForRectangle: self screenMorph bounds.
		(BitBlt current toForm: mergeForm) copyForm: self screenForm to: 0@0 rule: Form and
			colorMap: (Bitmap with: 0 with: 16rFFFFFFFF).
		aCanvas paintImage: mergeForm at: self screenMorph position]