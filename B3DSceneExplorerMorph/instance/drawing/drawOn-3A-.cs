drawOn: aCanvas
	"Don't fill if my b3dScene does it"
	(b3DSceneMorph notNil and:[b3DSceneMorph color isOpaque]) ifTrue:[
		(aCanvas clipRect areasOutside: b3DSceneMorph bounds) do:[:r|
			aCanvas clipBy: r during:[:cc| super drawOn: cc].
		].
	] ifFalse:[super drawOn: aCanvas].