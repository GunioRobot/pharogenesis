alanKwdSetter2: aNode isAConditional: template key: key args: args
	"translates
		foo setHeading: 0
	to
		foo's heading _ 0
	"
	| kwdHolder wordy |
	kwdHolder _ self
		addToken: key
		type: #keywordSetter
		on: (SelectorNode new key: key code: nil "fill this in?").
	wordy _ self translateToWordySetter: key.
	kwdHolder firstSubmorph 
		setProperty: #syntacticReformatting toValue: #keywordSetter;
		contents: wordy;
		emphasis: TextEmphasis bold emphasisCode.
	wordy = key asString ifFalse: [
		kwdHolder firstSubmorph 
			setProperty: #syntacticallyCorrectContents toValue: key asString].

	(args first asMorphicSyntaxIn: self) setConditionalPartStyle
			
