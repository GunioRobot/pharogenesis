drawSubmorphsOn: aCanvas
	"Display submorphs back to front"
	| drawBlock |
	submorphs size = 0 ifTrue:[^self].
	drawBlock _ [:canvas| submorphs reverseDo:[:m| canvas fullDrawMorph: m]].
	self clipSubmorphs ifTrue:[
		aCanvas clipBy: self clippingBounds during: drawBlock.
	] ifFalse:[
		drawBlock value: aCanvas.
	].