createButtonBar
	| bar button narrowFont registeredFonts |
	registeredFonts := OrderedCollection new.
	TextStyle knownTextStylesWithoutDefault do:
		[:st | (TextStyle named: st) fonts do: [:f | registeredFonts addLast: f]].		
	narrowFont := registeredFonts detectMin:
			[:ea | ea widthOfString: 'Contents' from: 1 to: 8].
	bar := AlignmentMorph newRow.
	bar
		color: self defaultBackgroundColor;
		rubberBandCells: false;
		vResizing: #shrinkWrap;
		cellInset: 6 @ 0.
	#(#('New\Archive' #canCreateNewArchive #createNewArchive 'Create a new, empty archive and discard this one') #('Load\Archive' #canOpenNewArchive #openNewArchive 'Open another archive and discard this one') #('Save\Archive As' #canSaveArchive #saveArchive 'Save this archive under a new name') #('Extract\All' #canExtractAll #extractAll 'Extract all this archive''s members into a directory') #('Add\File' #canAddMember #addMember 'Add a file to this archive') #('Add from\Clipboard' #canAddMember #addMemberFromClipboard 'Add the contents of the clipboard as a new file') #('Add\Directory' #canAddMember #addDirectory 'Add the entire contents of a directory, with all of its subdirectories') #('Extract\Member As' #canExtractMember #extractMember 'Extract the selected member to a file') #('Delete\Member' #canDeleteMember #deleteMember 'Remove the selected member from this archive') #('Rename\Member' #canRenameMember #renameMember 'Rename the selected member') #('View All\Contents' #canViewAllContents #changeViewAllContents 'Toggle the view of all the selected member''s contents')) 
		do: 
			[:arr | 
			| buttonLabel |
			buttonLabel := (TextMorph new)
						string: arr first withCRs
							fontName: narrowFont familyName
							size: narrowFont pointSize
							wrap: false;
						hResizing: #shrinkWrap;
						lock;
						yourself.
			(button := PluggableButtonMorph 
						on: self
						getState: arr second
						action: arr third)
				vResizing: #shrinkWrap;
				hResizing: #spaceFill;
				onColor: self buttonOnColor offColor: self buttonOffColor;
				label: buttonLabel;
				setBalloonText: arr fourth.
			bar addMorphBack: button.
			buttonLabel composeToBounds].
	^bar