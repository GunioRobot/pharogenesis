askIfAddStyle: priorMethod req: requestor
	"Ask the user if we have a complex style (i.e. bold) for the first time"
	| tell answ old |
	(Preferences browseWithPrettyPrint and: [Preferences colorWhenPrettyPrinting])
		ifTrue: [self couldDeriveFromPrettyPrinting ifTrue: [^ self asString]].
	self runs coalesce.
	self unembellished ifTrue: [^ self asString].
	priorMethod ifNotNil: [old _ priorMethod getSourceFromFile].
	(old == nil or: [old unembellished])
		ifTrue:
			[tell _ 'This method contains style (e.g. bold) for the first time.
Do you really want to save the style info?'.
			answ _ (PopUpMenu labels: 'Save method with style
Save method simply')
						startUpWithCaption: tell.
			answ = 2 ifTrue: [^ self asString]]