showColor
	"Display the current color in all brushes, both on and off."

	| offIndex onIndex byteIndex |
	currentColor ifNil: [^ self].
	colorPatch color: currentColor.	"May delete later"
	(brushes == nil or: [brushes first owner ~~ self]) ifTrue: [
		brushes _ OrderedCollection new.
		#(brush1: brush2: brush3: brush4: brush5: brush6:) do: [:sel |
			brushes addLast: (self findButton: sel)]].
	(brushes at: 6) offImage depth = 8 ifFalse: [self error: 'this code not able to handle it yet'].
	byteIndex _ (brushes at: 6) offImage bits size * 4 // 2.	"a byte in the center of picture."
	offIndex _ (brushes at: 6) offImage bits byteAt: byteIndex.	"raw pixel value, not mapped"
	onIndex _ (brushes at: 6) onImage bits byteAt: byteIndex.		"raw pixel value, not mapped"
	brushes do: [:bb |
		bb offImage colors at: offIndex+1 put: currentColor.
		bb offImage colors: bb offImage colors.	"force a remap, very slow"
		bb onImage colors at: onIndex+1 put: currentColor.
		bb onImage colors: bb onImage colors.	"force a remap, very slow"
		bb invalidRect: bb bounds].
	self invalidRect: (brushes first topLeft rect: brushes last bottomRight).
