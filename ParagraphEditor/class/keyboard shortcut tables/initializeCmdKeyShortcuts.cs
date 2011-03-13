initializeCmdKeyShortcuts
	"Initialize the (unshifted) command-key (or alt-key) shortcut table."

	"NOTE: if you don't know what your keyboard generates, use Sensor kbdTest"

	"ParagraphEditor initialize"

	| cmdMap |

	cmdMap := Array new: 256 withAll: #noop:.	"use temp in case of a crash"

	cmdMap at: 1 + 1 put: #cursorHome:.			"home key"
	cmdMap at: 4 + 1 put: #cursorEnd:.				"end key"
	cmdMap at: 8 + 1 put: #backspace:.				"ctrl-H or delete key"
	cmdMap at: 11 + 1 put: #cursorPageUp:.		"page up key"
	cmdMap at: 12 + 1 put: #cursorPageDown:.	"page down key"
	cmdMap at: 13 + 1 put: #crWithIndent:.			"cmd-Return"
	cmdMap at: 27 + 1 put: #offerMenuFromEsc:.	"escape key"
	cmdMap at: 28 + 1 put: #cursorLeft:.			"left arrow key"
	cmdMap at: 29 + 1 put: #cursorRight:.			"right arrow key"
	cmdMap at: 30 + 1 put: #cursorUp:.				"up arrow key"
	cmdMap at: 31 + 1 put: #cursorDown:.			"down arrow key"
	cmdMap at: 32 + 1 put: #selectWord:.			"space bar key"
	cmdMap at: 127 + 1 put: #forwardDelete:.		"del key"

	'0123456789-=' 
		do: [:char | cmdMap at: char asciiValue + 1 put: #changeEmphasis:].

	'([{''"<' do: [:char | cmdMap at: char asciiValue + 1 put: #enclose:].

	cmdMap at: $, asciiValue + 1 put: #shiftEnclose:.

	"triplet = {character. comment selector. novice appropiated}"
	#(
		($a		#selectAll:				true)
		($b		#browseIt:				false)
		($c		#copySelection:			true)
		($d		#doIt:						false)
		($e		#exchange:				true)
		($f		#find:						true)
		($g		#findAgain:				true)
		($h		#setSearchString:		true)
		($i		#inspectIt:				false)
		($j		#doAgainOnce:			true)
		($k		#offerFontMenu:		true)
		($l		#cancel:					true)
		($m	#implementorsOfIt:		false)
		($n		#sendersOfIt:			false)
		($o		#spawnIt:				false)
		($p		#printIt:					false)
		($q		#querySymbol:			false)
		($s		#save:					true)
		($t		#tempCommand:		false)
		($u		#align:					true)
		($v		#paste:					true)
		($w	#backWord:				true)
		($x		#cut:						true)
		($y		#swapChars:				true)
		($z		#undo:					true)
	)
		select:[:triplet | Preferences noviceMode not or:[triplet third]]
		thenDo:[:triplet | cmdMap at: triplet first asciiValue + 1 put: triplet second].

	CmdActions := cmdMap.
