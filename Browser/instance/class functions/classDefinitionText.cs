classDefinitionText
	"return the text to display for the definition of the currently selected class"
	| theClass |
	theClass := self selectedClassOrMetaClass.
	theClass ifNil: [ ^''].

	^theClass definitionST80.