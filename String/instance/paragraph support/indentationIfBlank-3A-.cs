indentationIfBlank: aBlock
	"Answer the number of leading tabs in the receiver.  If there are
	 no visible characters, pass the number of tabs to aBlock and return its value."

	| reader leadingTabs lastSeparator cr tab ch |
	cr _ Character cr.
	tab _ Character tab.
	reader _ ReadStream on: self.
	leadingTabs _ 0.
	[reader atEnd not and: [(ch _ reader next) == tab]]
		whileTrue: [leadingTabs _ leadingTabs + 1].
	lastSeparator _ leadingTabs + 1.
	[reader atEnd not and: [ch isSeparator and: [ch ~~ cr]]]
		whileTrue: [lastSeparator _ lastSeparator + 1. ch _ reader next].
	lastSeparator = self size | (ch == cr)
		ifTrue: [^aBlock value: leadingTabs].
	^leadingTabs