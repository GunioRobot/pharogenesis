abandonTempNames
	"Replaces every method by a copy with no source pointer or encoded temp names."
	"Smalltalk abandonTempNames"

	 | continue oldMethods newMethods n m |
	continue _ (self confirm:  '-- CAUTION --
If you have backed up your system and
are prepared to face the consequences of
abandoning all source code, hit Yes.
If you have any doubts, hit No,
to back out with no harm done.').
	continue ifFalse: [^ self inform: 'Okay - no harm done'].

	Smalltalk forgetDoIts; garbageCollect.
	oldMethods _ OrderedCollection new.
	newMethods _ OrderedCollection new.
	n _ 0.
	'Removing temp names to save space...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: CompiledMethod instanceCount
		during: [:bar |
			Smalltalk allBehaviorsDo: [:cl |
				cl selectors do: [:sel |
					bar value: (n _ n + 1).
					m _ cl compiledMethodAt: sel.
					oldMethods addLast: m.
					newMethods addLast: (m copyWithTrailerBytes: #(0))]]].
	oldMethods asArray elementsExchangeIdentityWith: newMethods asArray.
	Smalltalk closeSourceFiles.
	Preferences disable: #warnIfNoChangesFile.
	Preferences disable: #warnIfNoSourcesFile.
