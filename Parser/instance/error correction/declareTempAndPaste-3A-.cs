declareTempAndPaste: name
	| insertion tabbed |
	(requestor text string at: tempsMark) = $|
				ifTrue:  "Paste it before the second vertical bar"
					[tempsMark _ tempsMark +
						(self substituteWord: name , ' '
							wordInterval: (tempsMark to: tempsMark-1)
							offset: 0)]
				ifFalse:  "No bars - insert some with CR, tab"
					[insertion _ '| ' , name , ' |
'.
					tabbed _ tempsMark > 1
						and: [(requestor text string at: tempsMark-1) = Character tab].
					tabbed
						ifTrue: [insertion _ insertion , (String with: Character tab)].
					tempsMark _ tempsMark +
						(self substituteWord: insertion
							wordInterval: (tempsMark to: tempsMark-1)
							offset: 0)
						- (tabbed ifTrue: [3] ifFalse: [2])].
			^ encoder reallyBind: name