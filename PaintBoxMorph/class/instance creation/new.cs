new

	| pb button dualUse formCanvas rect |
	pb _ Prototype veryDeepCopy.
		"Assume that the PaintBox does not contain any scripted Players!"
	pb stampHolder normalize.	"Get the stamps to show"
	"Get my own copies of the brushes so I can modify them"
	#(brush1: brush2: brush3: brush4: brush5: brush6:) do: [:sel |
		button _ pb submorphNamed: sel.
		button offImage: button offImage deepCopy.
		dualUse _ button onImage == button pressedImage.	"sometimes shared"
		button onImage: button onImage deepCopy.
		dualUse
			ifTrue: [button pressedImage: button onImage]
			ifFalse: [button pressedImage: button pressedImage deepCopy].
		"force color maps for later mapping"
		button offImage.
		button onImage.
		button pressedImage.
		formCanvas _ button onImage getCanvas.
		formCanvas _ formCanvas
			copyOrigin: 0@0
			clipRect: (rect _ 0@0 extent: button onImage extent).
		(#(brush1: brush3:) includes: sel) ifTrue: [
			rect _ rect origin corner: rect corner - (2@2)].
		(#brush2: == sel) ifTrue: [
			rect _ rect origin corner: rect corner - (2@4)].
		formCanvas frameAndFillRectangle: rect fillColor: Color transparent
			borderWidth: 2 borderColor: (Color r: 0.599 g: 0.8 b: 1.0).
		].
	pb showColor.
	pb fixUpRecentColors.
	pb addLabels.
	^ pb