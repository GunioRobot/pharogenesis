abandonSources    "Smalltalk abandonSources"
	"Replaces every method by a copy with the 4-byte source pointer 
	replaced by a string of all arg and temp names, followed by its length.
	These names can then be used to inform the decompiler.  See stats below"
	"wod 11/3/1998: zap the organization before rather than after condensing changes."
	 | oldCodeString argsAndTemps bTotal bCount oldMethods newMethods m |
	(self confirm:  '-- CAUTION --
If you have backed up your system and
are prepared to face the consequences of
abandoning source code files, hit Yes.
If you have any doubts, hit No,
to back out with no harm done.')
		==  true ifFalse: [^ self inform: 'Okay - no harm done'].
	Smalltalk forgetDoIts.
	oldMethods _ OrderedCollection new: CompiledMethod instanceCount.
	newMethods _ OrderedCollection new: CompiledMethod instanceCount.
	bTotal _ 0.  bCount _ 0.
	Smalltalk allBehaviorsDo: [: b | bTotal _ bTotal + 1].
'Saving temp names for better decompilation...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: bTotal
	during: [:bar |
	Smalltalk allBehaviorsDo:    "for test:  (Array with: Arc with: Arc class) do: "
		[:cl |  bar value: (bCount _ bCount + 1).
		cl selectors do:
			[:selector |
			m _ cl compiledMethodAt: selector.
			m fileIndex > 0 ifTrue:
			[oldCodeString _ cl sourceCodeAt: selector.
			argsAndTemps _ (cl compilerClass new
				parse: oldCodeString in: cl notifying: nil)
				tempNames.
			oldMethods addLast: m.
			newMethods addLast: (m copyWithTempNames: argsAndTemps)]]]].
	oldMethods asArray elementsExchangeIdentityWith: newMethods asArray.
	Smalltalk allBehaviorsDo: [: b | b zapOrganization].
	Smalltalk condenseChanges.
	Preferences disable: #warnIfNoSourcesFile.
"
In a system with 7780 methods, we got 83k of temp names, or around 100k with spaces between.  The order of letter frequency was eatrnoislcmdgpSub, with about 60k falling in the first 11.  This suggests that we could encode in 4 bits, with 0-11 beng most common chars, and 12-15 contributing 2 bits to the next nibble for 6 bits, enough to cover all alphaNumeric with upper and lower case.  If we get 3/4 in 4 bits and 1/4 in 8, then we get 5 bits per char, or about 38% savings (=38k in this case).

Summary: about 13 bytes of temp names per method, or 8 with simple compression, plus 1 for the size.  This would be 5 bytes more than the current 4-byte trailer.
"