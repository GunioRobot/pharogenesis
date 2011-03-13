morphFromKeywords: key arguments: args on: parent indent: ignored
	| keywords column row receiverMorph firstArgMorph receiverWidth
messageWidth onlyOne selfWithNilReceiver |
	receiver ifNotNil: ["i.e. not a cascade"
			receiverMorph _ receiver asMorphicSyntaxIn: parent].
	keywords _ key keywords.
	args size = 0 ifTrue:
			[row _ (parent addTextRow: key) layoutInset: 1.
			^ row parseNode: selector].
	receiverWidth _ receiver
				ifNil: [0]
				ifNotNil: [receiverMorph fullBounds width].
	onlyOne _ args size = 1.
	(receiverWidth <= 80 and: [onlyOne])
		ifTrue: [row _ (parent addTextRow: keywords first) layoutInset: 1.
			row parseNode: selector.
			firstArgMorph _ args first asMorphicSyntaxIn: parent.
			receiver ifNil: [^ self].
			(firstArgMorph fullBounds height > 100
					or: [firstArgMorph fullBounds width > 250])
				ifTrue: [parent foldMessageOneArg].
			^ self].
	selfWithNilReceiver _ self copy receiver: nil.
	column _ parent addColumn: #keyword1 on: selfWithNilReceiver.
	messageWidth _ 0.
	keywords
		with: (args copyFrom: 1 to: keywords size)
		do: [:kwd :arg |
			(row _ column addRow: #keyword2 on: selfWithNilReceiver) borderWidth: 1;
				parseNode: (selfWithNilReceiver as: 
						(onlyOne ifTrue: [MessageNode] ifFalse: [MessagePartNode]));
				 borderColor: row stdBorderColor.
			row addToken: kwd
				type: #keyword2
				on: (onlyOne ifTrue: [SelectorNode new key: kwd code: nil "fill this in?"]
								ifFalse: [KeyWordNode new]).
			arg asMorphicSyntaxIn: row.
			messageWidth _ messageWidth + row fullBounds width].
	receiverMorph ifNotNil:
		[receiverWidth + messageWidth < 350 ifTrue: [^ parent unfoldMessage].
			((receiverWidth > 200
						or: [receiverWidth > 80
								and: [column fullBounds height > 20]])
					or: [receiverMorph fullBounds width > 30
							and: [column fullBounds height > 100
									or: [column fullBounds width > 250]]])
				ifTrue: [^ parent foldMessage]]