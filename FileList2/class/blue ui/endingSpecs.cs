endingSpecs

	^#(
		('Art' ('bmp' 'gif' 'jpg' 'form' 'png')
			(('open image in a window' openImageInWindow 'View')
			('read image into ImageImports' importImage 'Import')
			('open image as background' openAsBackground 'World'))
		)

		('Morphs' ('morph' 'morphs' 'sp')
			(('load as morph' openMorphFromFile 'Morph')
			('load as project' openProjectFromFile 'Project'))
		)

		('Projects' ('extseg' 'project' 'pr') (('load as project' openProjectFromFile 'Load')))

		('Books' ('bo') (('load as book' openBookFromFile 'Open')))

		('Music' ('mid') (('play midi file' playMidiFile 'Play')))

		('Movies' ('movie') (('open as movie' openAsMovie 'Open')))

		"('Code' ('st' 'cs')
			(('fileIn' fileInSelection)
			('file into new change set' fileIntoNewChangeSet)
			('browse changes' browseChanges)
			('browse code' browseFile)
			('remove line feeds' removeLinefeeds)
			('broadcast as update' putUpdate))
		)"

		('Flash' ('swf') (('open as Flash' openAsFlash 'Open')))

		('TrueType' ('ttf') (('open true type font' openAsTTF 'Open')))

		('3ds' ('3ds') (('Open 3DS file' open3DSFile' Open')))

		('Tape' ('tape') (('open for playback' openTapeFromFile 'Open')))

		('Wonderland' ('wrl') (('open in Wonderland' openVRMLFile 'Open')))

		('HTML' ('htm' 'html') (('open in browser' openInBrowser 'Open')))

	)