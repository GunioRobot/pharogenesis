scriptorForTextualScript: aSelector ofPlayer: aPlayer
	| aScriptor |
	self world ifNil: [^ nil].
	aScriptor _ ScriptEditorMorph new setMorph: aPlayer costume scriptName: aSelector.
	aScriptor position: (self primaryHand position - (10 @ 10)).
	^ aScriptor