openOnClass: aTargetClass inWorld: aWorld showingSelector: aSelector
	"Create and open a SystemWindow to house the receiver, showing the categories pane.  The target-object parameter is optional -- if nil, the browser will be associated with the class as a whole but not with any particular instance of it."

	| window aListMorph catListFraction |

	currentVocabulary ifNil: [currentVocabulary _ Vocabulary fullVocabulary].
	targetClass _ aTargetClass.
	self initialLimitClass.
	
	window _ self windowWithLabel: self startingWindowTitle.

	catListFraction _ 0.20.
	
	window addMorph: self newCategoryPane frame: (0 @ 0 corner: 0.5 @ catListFraction).

	aListMorph _ PluggableListMorph new.
	aListMorph 	setProperty: #balloonTextSelectorForSubMorphs toValue: #balloonTextForLexiconString.
	aListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph setNameTo: 'messageList'.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph frame: (0.5 @ 0 corner: 1 @ catListFraction).
		"side by side"

	self reformulateCategoryList.
	"needs to do this here because otherwise the following will break due to change 5738"

	self 
		addLowerPanesTo: window 
		at: (0 @ catListFraction  corner: 1@1) 
		with: nil.

	window changeAllBorderColorsFrom: Color black to: (self defaultBackgroundColor mixed: 0.5 with: Color black).
	window color: self defaultBackgroundColor.

	window openInWorld: aWorld.
	aSelector ifNotNil: [self selectSelectorItsNaturalCategory: aSelector] ifNil: [self categoryListIndex: 1].
	#(navigateToPreviousMethod	 navigateToNextMethod removeFromSelectorsVisited) do:
		[:sel |
			(self buttonWithSelector: sel) ifNotNilDo:
				[:aButton | aButton borderWidth: 0]].

	self adjustWindowTitle