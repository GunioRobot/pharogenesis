showModally
	"Use ToolBuilder if available."
	
	|tb|
	modal := true.
	(tb := Smalltalk at: #ToolBuilder ifAbsent: []) notNil
		ifTrue: [morph := tb open: self]
		ifFalse: [self window openInWorldExtent: (400@400)].
	[self window world notNil] whileTrue: [
		self window outermostWorldMorph doOneCycle].
	morph := nil.
	^ modalValue