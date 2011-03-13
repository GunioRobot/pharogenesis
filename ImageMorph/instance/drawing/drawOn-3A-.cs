drawOn: aCanvas
	self isOpaque
		ifTrue:[aCanvas drawImage: image at: bounds origin]
		ifFalse:[aCanvas paintImage: image at: bounds origin]