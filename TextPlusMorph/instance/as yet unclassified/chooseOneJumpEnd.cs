chooseOneJumpEnd

	| menu |

	menu _ CustomMenu new.
	self allJumpEndStrings do: [ :each |
		menu 
			add: each 
			action: each
	].
	^menu build startUpCenteredWithCaption: 'Possible jump ends'.
	
