scriptorForTextualScript: aSelector ofPlayer: aPlayer
	| aScriptor |
	aScriptor _ ScriptEditorMorph new setMorph: aPlayer costume scriptName: aSelector.
	aScriptor position: (self primaryHand position - (10 @ 10)).
	^ aScriptor