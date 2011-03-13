doWithProgressBar: aBlock forUnsentMessagesInClass: class
	| progressMessages selectors |
	progressMessages := 'Unsent messages in class ', class name.
	selectors := class selectors asArray.
	progressMessages
		displayProgressAt: Display center
		from: 0 to: selectors size
		during: [:bar | 
			selectors with: (0 to: selectors size - 1) do: [:selector :index|
				bar value: index.
				(self isUnsentMessage: selector) ifTrue: [aBlock value: class value: selector] ]]
