prepareAction: newEvent
	|  range  palNib |
	currentColor _ palette getColor.
	palNib _ palette getNib.
	(currentNib notNil 
		and:[currentNib extent = palNib extent 
		and:[currentNib isColorForm 
		and:[currentNib depth = 8 
		and:[currentNib colors last = currentColor]]]]) ifFalse:[
			currentNib _ self roundNibOfSize: (palette getNib extent).
			self aaPaintingEnabled
				ifTrue:[currentNib colors:((0 to: 255) collect:[:i| currentColor alpha: i / 255.0])]
				ifFalse:[currentNib colors: ((Array new: 256) at: 1 put: Color transparent; from: 2 to: 256 put: currentColor; yourself)].
		].
	currentActor _ newEvent getActor.
	currentCanvas _ (currentActor getTexturePointer getCanvas).
	range _ currentCanvas extent.
	currentPosition _ newEvent getVertex texCoords * range - (currentNib extent // 2).