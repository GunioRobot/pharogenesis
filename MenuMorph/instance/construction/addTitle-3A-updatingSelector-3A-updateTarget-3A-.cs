addTitle: aString updatingSelector: aSelector updateTarget: aTarget
	"Add a title line at the top of this menu  Make aString its initial contents.  If aSelector is not nil, then periodically obtain fresh values for its contents by sending aSelector to aTarget.."

	| title |
	title _ AlignmentMorph new.
	self setTitleParametersFor: title.
	title vResizing: #shrinkWrap.
	title listDirection: #topToBottom.
	title wrapCentering: #center; cellPositioning: #topCenter.
	aSelector
		ifNotNil:
			[title addMorphBack: (UpdatingStringMorph new lock; useStringFormat; target: aTarget; getSelector: aSelector)]
		ifNil:
			[(aString asString findTokens: String cr) do:
				[:line | title addMorphBack: (StringMorph contents: line font: Preferences standardMenuFont)]].
	
	self addMorphFront: title.
