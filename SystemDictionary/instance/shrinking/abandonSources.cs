abandonSources
	"Smalltalk abandonSources"
	"Replaces every method by a copy with the 4-byte source
	pointer 
	replaced by a string of all arg and temp names, followed by its
	length. These names can then be used to inform the
	decompiler. See stats below"
	"wod 11/3/1998: zap the organization before rather than after
	condensing changes."
	| oldCodeString argsAndTemps oldMethods newMethods m bTotal bCount |
	(self confirm: 'This method will preserve most temp names
(up to about 400 characters) while allowing
the sources file to be discarded.
-- CAUTION --
If you have backed up your system and
are prepared to face the consequences of
abandoning source code files, choose Yes.
If you have any doubts, you may choose No
to back out with no harm done.')
			== true
		ifFalse: [^ self inform: 'Okay - no harm done'].
	self forgetDoIts.
	oldMethods := OrderedCollection new: CompiledMethod instanceCount.
	newMethods := OrderedCollection new: CompiledMethod instanceCount.
	bTotal := 0.
	bCount := 0.
	self systemNavigation
		allBehaviorsDo: [:b | bTotal := bTotal + 1].
	'Saving temp names for better decompilation...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: bTotal
		during: [:bar | self systemNavigation
				allBehaviorsDo: [:cl | 
					"for test: (Array with: Arc with: Arc class) do:"
					bar value: (bCount := bCount + 1).
					cl selectors
						do: [:selector | 
							m := cl compiledMethodAt: selector.
							m fileIndex > 0
								ifTrue: [oldCodeString := cl sourceCodeAt: selector.
									argsAndTemps := (cl compilerClass new
												parse: oldCodeString
												in: cl
												notifying: nil) tempNames.
									oldMethods addLast: m.
									newMethods
										addLast: (m copyWithTempNames: argsAndTemps)]]]].
	oldMethods asArray elementsExchangeIdentityWith: newMethods asArray.
	self systemNavigation
		allBehaviorsDo: [:b | b zapOrganization].
	self condenseChanges.
	Preferences disable: #warnIfNoSourcesFile