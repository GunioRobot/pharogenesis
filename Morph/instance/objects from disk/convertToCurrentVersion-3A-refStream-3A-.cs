convertToCurrentVersion: varDict refStream: smartRefStrm

	(varDict at: #ClassName) == #DropShadowMorph ifTrue: [
		varDict at: #ClassName put: #Morph.	"so we don't
repeat this"
		^ self convertNovember2000DropShadow: varDict using:
smartRefStrm
			"always returns a new object of a different class"
	].
	varDict at: 'costumee' ifPresent: [ :x |
		self convertAugust1998: varDict using: smartRefStrm].
		"never returns a different object"

	"5/18/2000"
	varDict at: 'openToDragNDrop' ifPresent: [ :x | self
enableDragNDrop: x ].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.


