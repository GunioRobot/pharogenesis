rebuildOptionalButtons

	| answer |

	answer _ {
		self transparentSpacerOfSize: 20@3.
		self 
			buttonNamed: 'Button' translated action: #doButtonProperties color: color lighter 
			help: 'open a button properties panel for the morph' translated.
	}.
	myTarget isTextMorph ifTrue: [
		answer _ answer, {
			self 
				buttonNamed: 'Text' translated action: #doTextProperties color: color lighter 
				help: 'open a text properties panel for the morph' translated.
		}.
	].
	^answer