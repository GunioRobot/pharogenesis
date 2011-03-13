saveContentsInFile
	"A bit of a hack to pass along this message to the controller or morph.  (Possibly this Workspace menu item could be deleted, since it's now in the text menu.)"
	| textMorph textView |

	textMorph := self dependents detect: [:dep | dep isKindOf: PluggableTextMorph] ifNone: [nil].
	textMorph notNil ifTrue: [^ textMorph saveContentsInFile].

	textView := self dependents detect: [:dep | dep isKindOf: PluggableTextView] ifNone: [nil].
	textView notNil ifTrue: [^ textView controller saveContentsInFile].
