checkBlock: node as: nodeName from: encoder maxArgs: maxArgs
	"vb: #canBeSpecialArgument for blocks hardcodes 0 arguments as the requirement for special blocks. We work around that here by further checking the number of arguments for blocks.."

	node canBeSpecialArgument ifTrue: 
		[^node isBlockNode].
	^node isBlockNode
		ifTrue:
			[node numberOfArguments <= maxArgs
				ifTrue: [true]
				ifFalse: [encoder notify: '<- ', nodeName , ' of ' ,
					(MacroSelectors at: special) , ' has too many arguments']]
		ifFalse:
			[encoder notify: '<- ', nodeName , ' of ' ,
					(MacroSelectors at: special) , ' must be a block or variable']