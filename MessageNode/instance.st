ParseNode
	subclass: #MessageNode
	instanceVariableNames: 'receiver selector precedence special arguments sizes equalNode caseErrorNode'
	classVariableNames:
		'MacroEmitters MacroPrinters MacroSelectors MacroSizers MacroTransformers NewStyleMacroEmitters NewStyleMacroSizers StdTypers ThenFlag'
	poolDictionaries: ''
	category: 'Compiler-ParseNodes'