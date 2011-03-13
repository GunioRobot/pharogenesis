convertFromUserScript: aUserScript
	"The argument represents an old UserScript object.  convert it over"

	defaultStatus _ aUserScript status.
	isTextuallyCoded _ aUserScript isTextuallyCoded.
	currentScriptEditor _ aUserScript currentScriptEditor.
	formerScriptingTiles _  aUserScript formerScriptEditors ifNotNil:
		[aUserScript formerScriptEditors collect:
			[:aScriptEditor |
				Array with: aScriptEditor timeStamp with: aScriptEditor submorphs allButFirst]]