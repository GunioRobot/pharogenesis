testAll

	| source tree total count systNav|
"
SyntaxMorph testAll
"
	systNav _ self systemNavigation.
	count _ total _ 0.
	systNav allBehaviorsDo: [ :aClass | total _ total + 1].
'Testing all behaviors'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: total
	during: [ :bar |
		systNav allBehaviorsDo: [ :aClass |
			bar value: (count _ count + 1).
			aClass selectors do: [ :aSelector |
				source _ (aClass compiledMethodAt: aSelector) getSourceFromFile.
				tree _ Compiler new 
					parse: source 
					in: aClass 
					notifying: nil.
				tree asMorphicSyntaxUsing: SyntaxMorph.
			].
		].	].


