guessWindowsFontFolderPath
	"Guess the location of the Windows font folder"
	| possibles d |

	possibles := Set new.
	'cdefghijklmnopqrstuvwxyz' do:[:drive |
		#('\windows\fonts' '\winnt\fonts') do:[:path |
			(d := FileDirectory on: drive asString, ':', path) exists
				ifTrue:[possibles add: d]]].
	possibles := possibles asSortedCollection: [:a :b | a directoryEntry creationTime >= b  directoryEntry creationTime].
	possibles ifNotEmpty:[^possibles first pathName].
	^nil
	
		 	
			