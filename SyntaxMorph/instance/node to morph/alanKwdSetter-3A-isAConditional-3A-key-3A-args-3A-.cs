alanKwdSetter: aNode isAConditional: template key: key args: args

	| nodeWithNilReceiver row kwdHolder |

	nodeWithNilReceiver _ aNode copy receiver: nil.
	(row _ self addRow: #keyword2 on: nodeWithNilReceiver)
		borderWidth: 1;
		parseNode: (nodeWithNilReceiver as: MessageNode);
		borderColor: row stdBorderColor.
	row addNoiseString: '''s' emphasis: 1.
	kwdHolder _ row
		addToken: key
		type: #keywordGetz
		on: (SelectorNode new key: key code: nil "fill this in?").
	kwdHolder firstSubmorph 
		setProperty: #syntacticReformatting toValue: #keywordGetz;
		setProperty: #syntacticallyCorrectContents toValue: key asString;
		contents: (self splitAtCapsAndDownshifted: (key asString allButLast: 5));
		emphasis: 1.
	row addNoiseString: '_' emphasis: 1.

	(args first asMorphicSyntaxIn: row) setConditionalPartStyle
			