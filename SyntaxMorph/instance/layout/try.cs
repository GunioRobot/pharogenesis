try
	"Evaluate me once"

	(parseNode class == MessageNode) | (parseNode class == LiteralNode) ifFalse: [^ self].
	^ Compiler evaluate: self decompile
				for: self actualObject
				logged: false.	"should do something to the player"