conflictsWithUpdatedMethods
	"Check this package for conflicts with methods in the image which are in newer updates."

	| localFileName stream updateNumberString updateNumber imageUpdateNumber updateNumberChangeSet conflicts fileStream |

	localFileName _ FileDirectory localNameFor: fullName.
	stream _ ReadStream on: sourceSystem.
	stream upToAll: 'latest update: #'.
	updateNumberString _ stream upTo: $].
	stream close.
	
	fileStream := FileStream readOnlyFileNamed: fullName.
	(fileStream contentsOfEntireFile includes: Character linefeed)
		ifTrue: [self notifyWithLabel:  'The changeset file ', localFileName, ' contains linefeeds.  Proceed if...
you know that this is okay (e.g. the file contains raw binary data).'].
	fileStream close.

	updateNumberString isEmpty ifFalse:		"remove prepended junk, if any"
		[updateNumberString _ (updateNumberString findTokens: Character space) last].
	updateNumberString asInteger ifNil:
		[(self confirm: 'Error: ', localFileName, ' has no valid Latest Update number in its header.
Do you want to enter an update number for this file?')
			ifFalse: [^ self]
			ifTrue: [updateNumberString _ FillInTheBlank
						request: 'Please enter the estimated update number (e.g. 4332).']].
	updateNumberString asInteger ifNil: [self inform: 'Conflict check cancelled.'. ^ self].
	updateNumber _ updateNumberString asInteger.

	imageUpdateNumber _ SystemVersion current highestUpdate.
	updateNumber > imageUpdateNumber ifTrue:
		[(self confirm: 'Warning: The update number for this file (#', updateNumberString, ')
is greater than the highest update number for this image (#', imageUpdateNumber asString, ').
This probably means you need to update your image.
Should we proceed anyway as if the file update number is #', imageUpdateNumber asString, '?')
			ifTrue:
				[updateNumber _ imageUpdateNumber.
				updateNumberString _ imageUpdateNumber asString]
			ifFalse: [^ self]].

	updateNumberChangeSet _ self findUpdateChangeSetMatching: updateNumber.
	updateNumberChangeSet ifNil: [^ self].

	Smalltalk isMorphic ifTrue: [self currentWorld findATranscript: self currentEvent].
	self class logCr; logCr; log: 'Checking ', localFileName, ' (#', updateNumberString, ') for method conflicts with changesets after ', updateNumberChangeSet name, ' ...'.

	conflicts _ OrderedCollection new.
	self classes values do: [:pseudoClass |
		(Array with: pseudoClass with: pseudoClass metaClass) do: [:classOrMeta |
			classOrMeta selectors do: [:selector | | conflict |
				conflict _ self
							checkForMoreRecentUpdateThanChangeSet: updateNumberChangeSet
							pseudoClass: classOrMeta
							selector: selector.
				conflict ifNotNil: [conflicts add: conflict].
			].
		].
	].
	self class logCr; log: conflicts size asString, (' conflict' asPluralBasedOn: conflicts), ' found.'; logCr.
	self class closeLog.
	^ conflicts