classDefinitionText
	"return the text to display for the definition of the currently selected class"
	| theClass |
	theClass _ self selectedClassOrMetaClass.
	theClass ifNil: [ ^''].

	^theClass definitionST80: Preferences printAlternateSyntax not