blockNodeIn: homeMethodNode
	"Return the block node for self"

	homeMethodNode ifNil: [
		^ self decompilerClass new decompileBlock: self].

	homeMethodNode ir compiledMethod.  "generate method"
	homeMethodNode nodesDo: [:node |
		(node isBlock and:
		 [node scope isInlined not and:
		  [node ir compiledMethod = self]])
			ifTrue: [
				BlockNodeCache _ self -> node.
				^ node]
	].
	self errorNodeNotFound