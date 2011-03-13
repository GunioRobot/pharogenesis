startOutEmptyForScriptName: aScriptName
	"Make the receiver be an anonymous editor around initially empty content"
	scriptName _ aScriptName.
	self addMorphFront: self buttonRowForEditor.
	self updateStatus.
	firstTileRow _ 2.
	self install