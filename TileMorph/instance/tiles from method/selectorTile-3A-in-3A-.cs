selectorTile: msgNode in: aScriptor
	| sel selTile |
	"Make a selector (operator) tile"

	sel _ msgNode selector key.
	sel == #color:sees: ifTrue: [
		selTile _ (Viewer new) colorSeesPhrase submorphs second.	"ColorSeer tile"
		selTile colorSwatchColor: msgNode arguments first eval.
		^ selTile].
	^ self setOperator: sel