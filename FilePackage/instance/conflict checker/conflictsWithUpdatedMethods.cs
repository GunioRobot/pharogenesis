conflictsWithUpdatedMethods
	"Check this package for conflicts with methods in the image which are in newer updates."

	| localFileName stream updateNumberString updateNumber imageUpdateNumber updateNumberChangeSet conflicts fileStream |

	localFileName := FileDirectory localNameFor: fullName.
	stream := sourceSystem readStream.
	stream upToAll: 'latest update: #'.
	updateNumberString := stream upTo: $].
	stream close.
	
	fileStream := FileStream readOnlyFileNamed: fullName.
	(fileStream contentsOfEntireFile includes: Character linefeed)
		ifTrue: [self notifyWithLabel:  'The changeset file ', localFileName, ' contains linefeeds.  Proceed if...
you know that this is okay (e.g. the file contains raw binary data).'].
	fileStream close.

	updateNumberString isEmpty ifFalse:		"remove prepended junk, if any"
		[updateNumberString := (updateNumberString findTokens: Character space) last].
	updateNumberString asInteger ifNil:
		[(self confirm: 'Error: ', localFileName, ' has no valid Latest Update number in its header.
Do you want to enter an update number for this file?')
			ifFalse: [^ self]
			ifTrue: [updateNumberString := UIManager default
						request: 'Please enter the estimated update number (e.g. 4332).' translated]].
	(updateNumberString isEmptyOrNil or:	[updateNumberString asInteger isNil])
		ifTrue: [self inform: 'Conflict check cancelled.' translated. ^ self].
	updateNumber := updateNumberString asInteger.

	imageUpdateNumber := SystemVersion current highestUpdate.
	updateNumber > imageUpdateNumber ifTrue:
		[(self confirm: 'Warning: The update number for this file (#', updateNumberString, ')
is greater than the highest update number for this image (#', imageUpdateNumber asString, ').
This probably means you need to update your image.
Should we proceed anyway as if the file update number is #', imageUpdateNumber asString, '?')
			ifTrue:
				[updateNumber := imageUpdateNumber.
				updateNumberString := imageUpdateNumber asString]
			ifFalse: [^ self]].

	updateNumberChangeSet := self findUpdateChangeSetMatching: updateNumber.
	updateNumberChangeSet ifNil: [^ self].

	self currentWorld findATranscript: self currentEvent.
	self class logCr; logCr; log: 'Checking ', localFileName, ' (#', updateNumberString, ') for method conflicts with changesets after ', updateNumberChangeSet name, ' ...'.

	conflicts := OrderedCollection new.
	self classes values do: [:pseudoClass |
		(Array with: pseudoClass with: pseudoClass metaClass) do: [:classOrMeta |
			classOrMeta selectors do: [:selector | | conflict |
				conflict := self
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