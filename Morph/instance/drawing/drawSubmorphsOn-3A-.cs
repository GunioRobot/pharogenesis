drawSubmorphsOn: aCanvas 
	"Display submorphs back to front"

	| drawBlock |
	submorphs isEmpty ifTrue: [^self].
	drawBlock := [:canvas | submorphs reverseDo: [:m | canvas fullDrawMorph: m]].
	self clipSubmorphs 
		ifTrue: [aCanvas clipBy: self clippingBounds during: drawBlock]
		ifFalse: [drawBlock value: aCanvas]