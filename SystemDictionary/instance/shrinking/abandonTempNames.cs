abandonTempNames
	"Replaces every method by a copy with no source pointer or
	encoded temp names."
	"Smalltalk abandonTempNames"
	| continue oldMethods newMethods n m |
	continue := self confirm: '-- CAUTION --
If you have backed up your system and
are prepared to face the consequences of
abandoning all source code, hit Yes.
If you have any doubts, hit No,
to back out with no harm done.'.
	continue
		ifFalse: [^ self inform: 'Okay - no harm done'].
	self forgetDoIts; garbageCollect.
	oldMethods := OrderedCollection new.
	newMethods := OrderedCollection new.
	n := 0.
	'Removing temp names to save space...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: CompiledMethod instanceCount
		during: [:bar | self systemNavigation
				allBehaviorsDo: [:cl | cl selectors
						do: [:sel | 
							bar value: (n := n + 1).
							m := cl compiledMethodAt: sel.
							oldMethods addLast: m.
							newMethods
								addLast: (m copyWithTrailerBytes: #(0 ))]]].
	oldMethods asArray elementsExchangeIdentityWith: newMethods asArray.
	SmalltalkImage current closeSourceFiles.
	self flag: #shouldUseAEnsureBlockToBeSureThatTheFileIsClosed.
	"sd: 17 April 2003"
	Preferences disable: #warnIfNoChangesFile.
	Preferences disable: #warnIfNoSourcesFile