fileOutChangesFor: class on: stream 
	"Write out all the changes the receiver knows about this class.
	 5/15/96 sw: altered to call fileOutClassModifications:on: rather than fileOutClassChanges:on:, so that class headers won't go out as part of this process (they no go out at the beginning of the fileout"

	| changes |
					"first file out class changes"
	self fileOutClassModifications: class on: stream.
					"next file out changed methods"
	changes _ OrderedCollection new.
	(methodChanges at: class name ifAbsent: [^ self]) associationsDo: 
		[:mAssoc | 
		mAssoc value = #remove
			ifFalse: [changes add: mAssoc key]].
	changes isEmpty ifFalse: 
		[class fileOutChangedMessages: changes on: stream.
		stream cr]