changeScript: scriptName toStatus: statusSymbol
	| aWorld |
	scriptName ifNil: [^ self].
	Symbol hasInterned: scriptName ifTrue:
		[:sym | self instantiatedUserScriptsDo:
			[:aUserScript | aUserScript selector == sym
				ifTrue:
					[aUserScript status: statusSymbol.
					^ (aWorld _ self costume world) ifNotNil:
						[aWorld updateStatusForAllScriptEditors]]]]