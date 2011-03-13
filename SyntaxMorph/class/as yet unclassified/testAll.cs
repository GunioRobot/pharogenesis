testAll

	| source tree total count systNav|
"
SyntaxMorph testAll
"
	systNav := self systemNavigation.
	count := total := 0.
	systNav allBehaviorsDo: [ :aClass | total := total + 1].
'Testing all behaviors'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: total
	during: [ :bar |
		systNav allBehaviorsDo: [ :aClass |
			bar value: (count := count + 1).
			aClass selectors do: [ :aSelector |
				source := (aClass compiledMethodAt: aSelector) getSourceFromFile.
				tree := Compiler new 
					parse: source 
					in: aClass 
					notifying: nil.
				tree asMorphicSyntaxUsing: SyntaxMorph.
			].
		].	].


