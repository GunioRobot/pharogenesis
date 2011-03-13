useNewTilesNow
	| mp source aSelector aClass tree syn widget |
	"First make it show source with a method pane, then substitute tiles!"

	(mp _ self findA: MethodMorph) ifNil: [^ self].	"code pane must be present"
	aSelector _ mp model selectedMessageName.
	aClass _ mp model selectedClassOrMetaClass.
	source _ aClass sourceCodeAt: aSelector.    
	tree _ Compiler new 
		parse: source 
		in: aClass 
		notifying: nil.
	(syn _ tree asMorphicSyntaxUsing: SyntaxMorph)
		parsedInClass: aClass.
	widget _ syn inAScrollPane.
	widget color: Color transparent;
		setProperty: #hideUnneededScrollbars toValue: true;
		setProperty: #maxAutoFitSize toValue: 300@200.
	mp delete.
	self addMorphBack: widget.
	widget extent: (self width - 10 @ 150).
