drawOn: aCanvas

		super drawOn: aCanvas.	
		image = nil ifFalse:[aCanvas image: image at: bounds origin].