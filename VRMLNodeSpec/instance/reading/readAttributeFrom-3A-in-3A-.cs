readAttributeFrom: aVRMLStream in: aParser
	"Read an attribute"
	| attrName attrSpec attrValue |
	attrName := aVRMLStream readName.
	attrSpec := self attributeNamed: attrName.
	attrSpec notNil ifTrue:[
		attrValue := attrSpec readFrom: aVRMLStream in: aParser.
		^attrSpec -> attrValue].
	(aParser isStatement: attrName) ifTrue:[
		aParser parseStatement: attrName from: aVRMLStream.
		^nil].
	self warn:'Unknown attribute: ', attrName.
	aVRMLStream skip: 1.
	^nil