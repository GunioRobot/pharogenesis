tileScriptCommandsForBank: aBank
	"Return a list of typed-command arrays of the form:
		<result type> <command> <argType>
	Currently, put up to five on the first bank, the rest on the second"

	| sortedNames aList scriptCount |
	sortedNames _ self class namedTileScriptSelectors asSortedArray.  "perhaps too jarring"
	scriptCount _ sortedNames size.
	aBank == 1
		ifTrue:
			[aList _ (1 to: (scriptCount min: 3)) collect:
				[:i | Array with: #command with: (sortedNames at: i)]].
	aBank == 2
		ifTrue:
			[aList _ (4 to: (scriptCount  min: 6)) collect:
				[:i | Array with: #command with: (sortedNames at: i)]].

	aBank == 3
		ifTrue:
			[aList _ (7 to: (scriptCount min: 11)) collect:
				[:i | Array with: #command with: (sortedNames at: i)]].

	aBank == 4
		ifTrue:
			[aList _ (12 to: scriptCount) collect:
				[:i | Array with: #command with: (sortedNames at: i)]].

	^ aList asArray