scriptEditorFor: aSelector
	"Answer the receiver's script editor for aSelector"

	| aScriptEditor |
	aScriptEditor _ (self class userScriptForPlayer: self selector: aSelector) instantiatedScriptEditorForPlayer: self.
	aScriptEditor updateToPlayer: self.
	aScriptEditor bringUpToDate.
	^ aScriptEditor