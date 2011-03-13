installTilesForSelection
	"Install universal tiles into the code pane."
	| source aSelector aClass tree syn tileScriptor aWindow codePane |
	(aWindow _ self containingWindow)
		ifNil: [self error: 'hamna dirisha'].
	tileScriptor _ ((aSelector _ self selectedMessageName) isNil
					or: [(aClass _ self selectedClassOrMetaClass whichClassIncludesSelector: aSelector) isNil])
				ifTrue: [PluggableTileScriptorMorph new]
				ifFalse: [source _ aClass sourceCodeAt: aSelector.
					tree _ Compiler new
								parse: source
								in: aClass
								notifying: nil.
					(syn _ tree asMorphicSyntaxUsing: SyntaxMorph) parsedInClass: aClass.
					syn inAPluggableScrollPane].
	codePane _ aWindow
				findDeepSubmorphThat: [:m | (m isKindOf: PluggableTextMorph)
						and: [m getTextSelector == #contents]]
				ifAbsent: [].
	codePane
		ifNotNil: [codePane hideScrollBars].
	codePane
		ifNil: [codePane _ aWindow
						findDeepSubmorphThat: [:m | m isKindOf: PluggableTileScriptorMorph]
						ifAbsent: [self error: 'no code pane']].
	tileScriptor color: aWindow paneColorToUse;
		 setProperty: #hideUnneededScrollbars toValue: true.
	aWindow replacePane: codePane with: tileScriptor.
	currentCompiledMethod _ aClass
				ifNotNil: [aClass compiledMethodAt: aSelector].
	tileScriptor owner clipSubmorphs: true.
	tileScriptor extent: codePane extent