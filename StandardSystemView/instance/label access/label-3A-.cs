label: aString 
	"Set aString to be the receiver's label."
	labelText _ Paragraph
			withText: (Text string: ((aString == nil or: [aString isEmpty])
								ifTrue: ['Untitled' copy]
								ifFalse: [aString])
							attributes: (Array with: TextEmphasis bold))
			style: LabelStyle.
	insetDisplayBox == nil ifTrue: [^ self].  "wait for further initialization"
	self setLabelRegion