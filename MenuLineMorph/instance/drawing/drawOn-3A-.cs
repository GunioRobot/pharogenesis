drawOn: aCanvas 
	| baseColor |
	baseColor := Preferences menuColorFromWorld
				ifTrue: [owner color twiceDarker]
				ifFalse: [Preferences menuAppearance3d
						ifTrue: [owner color]
						ifFalse: [Preferences menuLineColor]].
	Preferences menuAppearance3d
		ifTrue: [
			aCanvas
				fillRectangle: (bounds topLeft corner: bounds rightCenter)
				color: baseColor twiceDarker.
			
			aCanvas
				fillRectangle: (bounds leftCenter corner: bounds bottomRight)
				color: baseColor twiceLighter]
		ifFalse: [
			aCanvas
				fillRectangle: (bounds topLeft corner: bounds bottomRight)
				color: baseColor]