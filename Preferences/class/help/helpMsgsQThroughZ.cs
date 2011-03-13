helpMsgsQThroughZ
	"Answer a list of <symbol> <string> pairs that give the balloon help corresponding to various symbols"

	^ #(	
(reverseWindowStagger
	'If true, a reverse-stagger strategy  is used for determining where newly launched windows will be placed; if false, a direct- stagger strategy is used.')

(roundedMenuCorners
	'Whether morphic menus should have rounded corners')

(roundedWindowCorners
	'Governs whether morphic system windows should have rounded corners')

(scrollBarsNarrow
		'If true, morphic scrollbars will be narrow.')
(scrollBarsOnRight
		'If true, morphic scrollbars in subsequently opened windows will appear on the right side of their pane.')
(scrollBarsWithoutMenuButton
		'If true, morphic scrollbars in subsequently opened windows will not include a menu button.')

(smartUpdating
	'If true, then morphic tools such as browsers and inspectors will keep their contents up to date automatically, so that if something changes anywhere, the change will be reflected everywhere.')

(soundQuickStart
	'If true, attempt to start playing sounds using optional "quick start"')

(soundsEnabled
	'If false, all sound playing is disabled')

(systemWindowEmbedOK
	'Determines whether, in Morphic, when a SystemWindow is dropped onto a willing receptor it should be deposited into that receptor.')

(timeStampsInMenuTitles
	'If true, then the author''s timestamp is displayed as the menu title of any message list; if false, no author''s timestamps are shown')

(thoroughSenders
	'If true, then ''senders'' browsers will dive inside structured literals in their search')

(twentyFourHourFileStamps
	'If #changeSetVersionNumbers is false, this preference determines whether the date/time suffix used with changeset fileouts is based on a 24-hr clock or a 12-hr clock.')

(uniformWindowColors
	'If true, then all standard windows are given the same color rather than their customized window-type-specific colors')

(unlimitedPaintArea
	'If true, the painting area for a new drawing will not be limited in size; if false, a reasonable
limit will be applied, in an attempt to hold down memory and time price.')

(updateRemoveSequenceNum
	'If true, then remove the leading sequence number from the filename before automatically saving a local copy of any update loaded.')

(updateSavesFile
	'If true, then when an update is loaded from the server, a copy of it will automatically be saved on a local file as well.')

(useGlobalFlaps
	'If true, then flaps are shown along the edges of Morphic projects.')

(viewersInFlaps
	'If true, viewers are projected into flaps along the right edge of the screen')

(warnIfNoChangesFile
	'If true, then you will be warned, whenever you start up, if no changes file
can be found')

(warnIfNoSourcesFile 
	'If true, then you will be warned, whenever you start up, if no sources file can be found')


			) 
