handleKeystroke: aChar
	"Answer the menu for this list view."

	| args aSpecialKey |

	aSpecialKey _ aChar asciiValue.
	aSpecialKey < 32 ifTrue: [ self specialKeyPressed: aSpecialKey. ^nil ].
	keystrokeActionSelector ifNil: [^ nil].

	controller controlTerminate.
	(args _ keystrokeActionSelector numArgs) = 1
		ifTrue: [model perform: keystrokeActionSelector with: aChar.
				^ controller controlInitialize].
	args = 2
		ifTrue: [model perform: keystrokeActionSelector with: aChar with: self.
				^ controller controlInitialize].
	^ self error: 'The keystrokeActionSelector must be a 1- or 2-keyword symbol'