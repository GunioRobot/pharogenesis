addTitle: aString updatingSelector: aSelector updateTarget: aTarget 
	"Add a title line at the top of this menu Make aString its initial 
	contents.  
	If aSelector is not nil, then periodically obtain fresh values for its 
	contents by sending aSelector to aTarget.."
	| title |
	title := AlignmentMorph new.
	self setTitleParametersFor: title.
	title vResizing: #shrinkWrap.
	title listDirection: #topToBottom.
	title wrapCentering: #center;
		 cellPositioning: #topCenter;

		 layoutInset: 0.
	aSelector
		ifNil: [(aString asString findTokens: String cr)
				do: [:line | title addMorphBack: (StringMorph new contents: line;
							 font: Preferences standardMenuFont)]]
		ifNotNil: [title addMorphBack: (UpdatingStringMorph new lock; font: Preferences standardMenuFont; useStringFormat; target: aTarget; getSelector: aSelector)].
	title setProperty: #titleString toValue: aString.
	self addMorphFront: title.
	(self hasProperty: #needsTitlebarWidgets)
		ifTrue: [self addStayUpIcons]