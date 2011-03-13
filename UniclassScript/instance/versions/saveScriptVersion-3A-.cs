saveScriptVersion: timeStamp
	"Save the tile script version by appending a pair of the form

		<time stamp>     <morph list>

to my list of former scripting tiles.  The morph-list will get copied back into the Scriptor following restoration."

	((currentScriptEditor notNil and: [currentScriptEditor showingMethodPane not]) and:
		[currentScriptEditor submorphs size > 1]) ifTrue:
			[formerScriptingTiles ifNil: [formerScriptingTiles _ OrderedCollection new].
			formerScriptingTiles add:
				(Array with: timeStamp
					with: (currentScriptEditor submorphs allButFirst collect: [:m | m fullCopyWithoutFormerOwner])).
			formerScriptingTiles size > 100 ifTrue: [^ self halt: 'apparent runaway versions']]