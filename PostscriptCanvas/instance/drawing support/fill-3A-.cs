fill:fillColor
	fillColor isSolidFill ifTrue:[
		self paint:fillColor asColor operation:#fill.
	] ifFalse: [
		 self gsave.
		 self clip.
		 self drawGradient:fillColor.
		 self grestore.
	].	


              