startFont: aTextAttribList
	"aTextAttribList is a collection of TextAttributes"
	fontSpecs ifNil: [fontSpecs _ OrderedCollection new].
	fontSpecs add: aTextAttribList.
	self setAttributes