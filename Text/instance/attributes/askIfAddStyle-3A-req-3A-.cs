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
			[tell _ 'This method contains style for the first time (e.g. bold or colored text).
Do you really want to save the style info?'.
			answ _ (UIManager default 
						chooseFrom: #('Save method with style' 'Save method simply')
						title: tell).
			answ = 2 ifTrue: [^ self asString]]