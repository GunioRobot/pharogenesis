attributeList
	"Answer a list of text attributes that characterize the receiver"
	attributeList ifNil:
		[attributeList _ OrderedCollection new: 2.
		color ifNotNil: [attributeList add: (TextColor color: color)].
		emphasis ifNotNil: [attributeList add: (TextEmphasis perform: emphasis)]].
	^ attributeList