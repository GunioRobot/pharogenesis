installTilesForSelection
	"Install universal tiles into the code pane."
	| source aSelector aClass tree syn tileScriptor aWindow codePane |
	(aWindow := self containingWindow)
		ifNil: [self error: 'hamna dirisha'].
	aSelector := self selectedMessageName.
	aClass := self selectedClassOrMetaClass
				ifNil: [targetClass].
	aClass
		ifNotNil: [aSelector
				ifNil: [source := SyntaxMorph sourceCodeTemplate]
				ifNotNil: [aClass := self selectedClassOrMetaClass whichClassIncludesSelector: aSelector.
					source := aClass sourceCodeAt: aSelector].
			tree := Compiler new
						parse: source
						in: aClass
						notifying: nil.
			(syn := tree asMorphicSyntaxUsing: SyntaxMorph) parsedInClass: aClass.
			tileScriptor := syn inAPluggableScrollPane].
	codePane := aWindow
				findDeepSubmorphThat: [:m | (m isKindOf: PluggableTextMorph)
						and: [m getTextSelector == #contents]]
				ifAbsent: [].
	codePane
		ifNotNil: [codePane hideScrollBars].
	codePane
		ifNil: [codePane := aWindow
						findDeepSubmorphThat: [:m | m isKindOf: PluggableTileScriptorMorph]
						ifAbsent: [self error: 'no code pane']].
	tileScriptor color: aWindow paneColorToUse;
		 setProperty: #hideUnneededScrollbars toValue: true.
	aWindow replacePane: codePane with: tileScriptor.
	currentCompiledMethod := aClass
				ifNotNil: [aClass
						compiledMethodAt: aSelector
						ifAbsent: []].
	tileScriptor owner clipSubmorphs: true.
	tileScriptor extent: codePane extent