showHintsWindow

	| hints |
	(self confirm: 'As hints, you will be given the five longest answers.
Do you really want to do this?') ifFalse: [^ self].
	hints _ (answers asSortedCollection: [:x :y | x size > y size]) asArray
		copyFrom: 1 to: 5.
	((StringHolder new contents: 
	'The five longest answers are...
'	,
	(String streamContents:
		[:strm | hints do: 
			[:hint | strm cr; nextPutAll: (hint collect: [:i | quote at: i])].
		strm cr; cr])
	,
'Good luck!')
		embeddedInMorphicWindowLabeled: 'Crostic Hints')
			setWindowColor: (Color r: 1.0 g: 0.6 b: 0.0);
			openInWorld: self world extent: 198@154