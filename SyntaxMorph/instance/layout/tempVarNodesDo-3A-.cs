tempVarNodesDo: aBlock
	"Execute the block for any block temporary variables, method temps, or method args we have"

	| tempHolder argsHolder |
	((self parseNode class == MethodNode) or: [self parseNode class == BlockNode]) ifTrue: [
		self submorphsDoIfSyntax: [:sub | 
				(sub nodeClassIs: MethodTempsNode) ifTrue: [tempHolder _ sub].
				((sub nodeClassIs: UndefinedObject) and: [tempHolder isNil]) ifTrue: [
					tempHolder _ sub findA: MethodTempsNode].
				(sub nodeClassIs: BlockArgsNode) ifTrue: [tempHolder _ sub].
				(sub nodeClassIs: SelectorNode) ifTrue: [argsHolder _ sub].
				]
			ifString: [:sub | ].
		tempHolder ifNotNil: ["Temp variables"
			tempHolder submorphsDoIfSyntax: [:sm | 
					(sm nodeClassIs: TempVariableNode) ifTrue: [aBlock value: sm]]
				ifString: [:sm | ]].
		argsHolder ifNotNil: ["arguments"
			argsHolder submorphsDoIfSyntax: [:sm | 
					(sm nodeClassIs: TempVariableNode) ifTrue: [aBlock value: sm]]
				ifString: [:sm | ]].
		].
	"otherwise do nothing"