acceptTiles
	| pp pq methodNode cls sel |
	"In complete violation of all the rules of pluggable panes, search dependents for my tiles, and tell them to accept."

	pp _ self dependents detect: [:pane | pane isKindOf: PluggableTileScriptorMorph] 
			ifNone: [^ Beeper beep].
	pq _ pp findA: TransformMorph.
	methodNode _ pq findA: SyntaxMorph.
	cls _ methodNode parsedInClass.
	sel _ cls compile: methodNode decompile classified: self selectedCategoryName
			notifying: nil.
	self noteAcceptanceOfCodeFor: sel.
	self reformulateListNoting: sel.