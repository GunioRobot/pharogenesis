convertAlignment
	self clipSubmorphs: true.
	(autoLineLayout == true) ifTrue:[
		self layoutPolicy: TableLayout new.
		self layoutInset: 8; cellInset: 4.
		self listDirection: #leftToRight; wrapDirection: #topToBottom.
		self minHeight: self height.
	] ifFalse:[
		self layoutPolicy: nil.
		self layoutInset: 0; cellInset: 0.
	].
	(resizeToFit == true) ifTrue:[
		self vResizing: #shrinkWrap.
	] ifFalse:[
		self vResizing: #rigid.
	].