stroke:strokeColor
	strokeColor ifNotNil:[
		strokeColor isSolidFill ifTrue:[
			self paint:strokeColor asColor operation:#stroke.
		] ifFalse: [
			 self gsave.
			 self strokepath.
			 self fill:strokeColor.
			 self grestore.
		].
	].	

              