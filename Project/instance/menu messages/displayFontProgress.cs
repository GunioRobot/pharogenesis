displayFontProgress
	"Display progress for fonts"
	| done b pp |
	done := false.
	b := ScriptableButton new.
	b color: Color yellow.
	b borderWidth: 1; borderColor: Color black.
	pp := [	| dots str idx |
		dots := #(' - ' ' \ ' ' | ' ' / '). idx := 0.
		[done] whileFalse:[
			str := '$	Fixing fonts	$	' translated.
			str := str copyReplaceTokens: '$' with: (dots atWrap: (idx := idx + 1)) asString.
			b label: str font: (TextStyle defaultFont emphasized: 1).
			b extent: 200@50.
			b center: Display center.
			b fullDrawOn: Display getCanvas.
			(Delay forMilliseconds: 250) wait.
		].
	] forkAt: Processor userInterruptPriority.
	^[done := true]