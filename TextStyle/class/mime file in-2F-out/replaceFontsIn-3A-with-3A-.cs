replaceFontsIn: oldFontArray with: newStyle
	"
	TextStyle replaceFontsIn: (TextStyle looseFontsFromFamily: #Accuny) with: (TextStyle named: #Accuny)
	"
	"Try to find corresponding fonts in newStyle and substitute them for the fonts in oldFontArray"

	newStyle fontArray do: [ :newFont | newFont releaseCachedState ].

	oldFontArray do: [ :oldFont | | newFont |
		oldFont reset.
		newFont _ (newStyle fontOfPointSize: oldFont pointSize) emphasis: oldFont emphasis.
		oldFont becomeForward: newFont ].

	StringMorph allSubInstancesDo: [ :s | s layoutChanged ].
	TextMorph allSubInstancesDo: [ :s | s layoutChanged ].
	SystemWindow allInstancesDo: [ :w | [ w update: #relabel ] on: Error do: [ :ex | ] ].
	World ifNotNilDo: [ :w | w changed ].