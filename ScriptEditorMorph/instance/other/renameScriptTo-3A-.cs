renameScriptTo: newSelector
	"Rename the receiver's script so that it bears a new selector"

	| aMethodNodeMorph methodMorph methodSource pos newMethodSource |

	scriptName _ newSelector.
	self updateHeader.
	Preferences universalTiles
		ifFalse:  "classic tiles"
			[self showingMethodPane
				ifTrue:
					["textually coded -- need to change selector"
					methodMorph _ self findA: MethodMorph.
					methodSource _ methodMorph text string.
					pos _ methodSource indexOf: Character cr ifAbsent: [self error: 'no cr'].
					newMethodSource _ newSelector.
					newSelector numArgs > 0 ifTrue: [newMethodSource _ newMethodSource, ' t1'].  "for the parameter"
					newMethodSource _ newMethodSource, (methodSource copyFrom: pos to: methodSource size).
					methodMorph editString: newMethodSource.
					methodMorph model changeMethodSelectorTo: newSelector.
					playerScripted class compile: newMethodSource classified: 'scripts'.
					methodMorph accept]
				ifFalse:
					[self install]]
		ifTrue:  "universal tiles..."
			[(aMethodNodeMorph _ self methodNodeMorph) ifNotNil:
				[aMethodNodeMorph acceptInCategory: 'scripts']]