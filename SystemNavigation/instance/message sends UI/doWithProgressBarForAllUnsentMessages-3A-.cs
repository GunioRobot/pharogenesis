doWithProgressBarForAllUnsentMessages: aBlock
	|progressMessages classes |
	Cursor wait showWhile: [classes := self allClasses].
	progressMessages := 'Unsent messages in all classes'.
	progressMessages
		displayProgressAt: Display center
		from: 0 to: classes size
		during: [:bar | 
			classes with: (0 to: classes size - 1) do: [:class :index|
				bar value: index.
				self doWithProgressBar: aBlock forUnsentMessagesInClass: class]]