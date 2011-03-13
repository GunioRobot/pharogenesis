rebuildOptionalButtons

	| answer |

	answer _ #() .
	
	myTarget isTextMorph ifTrue: [
		answer _ answer, {
			self 
				buttonNamed: 'Text' translated action: #doTextProperties color: color lighter 
				help: 'open a text properties panel for the morph' translated.
		}.
	].
	^answer