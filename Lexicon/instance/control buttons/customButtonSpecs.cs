customButtonSpecs
	"Answer a triplet defining buttons, in the format:

			button label
			selector to send
			help message"
	| aa |
	aa _ contentsSymbol == #tiles ifTrue: [{   "Consult Ted Kaehler regarding this bit"
	{'tiles'.				#tilesMenu.					'tiles for assignment and constants'. 	true}.
	{'vars'.				#varTilesMenu.	'tiles for instance variables and a new temporary'. 	true}
		}] ifFalse: [#()].	"true in 4th place means act on mouseDown"

	^ aa, #(
	('follow'			seeAlso							'view a method I implement that is called by this method')
	('find'				obtainNewSearchString			'find methods by name search')
	('sent...'			setSendersSearch				'view the methods I implement that send a given message')

	('<'					navigateToPreviousMethod 		'view the previous active method')
	('>'					navigateToNextMethod 			'view the next active method')
	('-'					removeFromSelectorsVisited		'remove this method from my active list'))