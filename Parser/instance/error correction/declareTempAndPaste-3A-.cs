declareTempAndPaste: name
	| insertion delta theTextString characterBeforeMark |

	theTextString _ requestor text string.
	characterBeforeMark _ theTextString at: tempsMark-1 ifAbsent: [$ ].
	(theTextString at: tempsMark) = $| ifTrue: [
  		"Paste it before the second vertical bar"
		insertion _ name, ' '.
		characterBeforeMark isSeparator ifFalse: [insertion _ ' ', insertion].
		delta _ 0.
	] ifFalse: [
		"No bars - insert some with CR, tab"
		insertion _ '| ' , name , ' |',String cr.
		delta _ 2.	"the bar and CR"
		characterBeforeMark = Character tab ifTrue: [
			insertion _ insertion , String tab.
			delta _ delta + 1.	"the tab"
		].
	].
	tempsMark _ tempsMark +
		(self substituteWord: insertion
			wordInterval: (tempsMark to: tempsMark-1)
			offset: 0) - delta.
	^ encoder bindAndJuggle: name