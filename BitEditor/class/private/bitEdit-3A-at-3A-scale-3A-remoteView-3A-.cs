bitEdit: aForm at: magnifiedFormLocation scale: scaleFactor remoteView: remoteView
	"Create a BitEditor on aForm. That is, aForm is a small image that will 
	change as a result of the BitEditor changing a second and magnified 
	view of me. magnifiedFormLocation is where the magnified form is to be 
	located on the screen. scaleFactor is the amount of magnification. This 
	method implements a scheduled view containing both a small and 
	magnified view of aForm. Upon accept, aForm is updated."

	| aFormView scaledFormView bitEditor topView extent menuView lowerRightExtent |
	scaledFormView := FormHolderView new model: aForm.
	scaledFormView scaleBy: scaleFactor.
	bitEditor := self new.
	scaledFormView controller: bitEditor.
	bitEditor setColor: Color black.
	topView := ColorSystemView new.
	remoteView == nil ifTrue: [topView label: 'Bit Editor'].
	topView borderWidth: 2.

	topView addSubView: scaledFormView.
	remoteView == nil
		ifTrue:  "If no remote view, then provide a local view of the form"
			[aFormView := FormView new model: scaledFormView workingForm.
			aFormView controller: NoController new.
			aForm height < 50
				ifTrue: [aFormView borderWidthLeft: 0 right: 2 top: 2 bottom: 2]
				ifFalse: [aFormView borderWidthLeft: 0 right: 2 top: 2 bottom: 0].
			topView addSubView: aFormView below: scaledFormView]
		 ifFalse:  "Otherwise, the remote one should view the same form"
			[remoteView model: scaledFormView workingForm].
	lowerRightExtent := remoteView == nil
			ifTrue:
				[(scaledFormView viewport width - aFormView viewport width) @
					(aFormView viewport height max: 50)]
			ifFalse:
				[scaledFormView viewport width @ 50].
	menuView := self buildColorMenu: lowerRightExtent colorCount: 1.
	menuView model: bitEditor.
	menuView borderWidthLeft: 0 right: 0 top: 2 bottom: 0.
	topView
		addSubView: menuView
		align: menuView viewport topRight
		with: scaledFormView viewport bottomRight.
	extent := scaledFormView viewport extent + (0 @ lowerRightExtent y)
			+ (4 @ 4).  "+4 for borders"
	topView minimumSize: extent.
	topView maximumSize: extent.
	topView translateBy: magnifiedFormLocation.
	topView insideColor: Color white.
	^topView