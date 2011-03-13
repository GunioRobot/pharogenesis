bug: aBugNo fix: aFileName date: aDate
 
	| stream |

	self setBug: aBugNo.

	self logCR: 'obtaining ', aFileName, '...'.

	stream := self maStreamForFile: aFileName.

	self ditchOldChangeSetFor: aFileName.

	self maCheckDateAgainst: aDate.

	self install: aFileName from: stream.

	self class fixesApplied add: aBugNo.
		
	^ date